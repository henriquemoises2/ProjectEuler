using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class NumberLetterCounts : IProblem
    {

        private const string MENU_ENTRY = "Number Letter Counts";

        private int countToNumber;

        #region Overrides

        public bool Run()
        {
            if (Introduction())
            {
                int total;
                total = CountLetters(countToNumber);
                Console.WriteLine("Total letter: " + total);
                return true;
            }
            else
            {
                return false;
            }

        }

        public string GetMenuEntry()
        {
            return MENU_ENTRY;
        }

        public bool Introduction()
        {
            Console.WriteLine("Enter number to count to:");
            if (int.TryParse(Console.ReadLine(), out countToNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Private Methods

        private int CountLetters(int number)
        {
            int numberDigits;
            string numbersText = String.Empty;

            for (int i = 1; i <= number; i++)
            {
                numberDigits = CountNumberDigits(i);
                switch (numberDigits)
                {
                    case 1:
                        numbersText += NumberWords.words[i];
                        break;

                    case 2:
                        if (i < 20)
                        {
                            numbersText += NumberWords.words[i];
                        }
                        else
                        {
                            int[] digits2 = GetDigits(i);
                            if (digits2.Last() == 0)
                            {
                                numbersText += NumberWords.words[i];
                            }
                            else
                            {
                                numbersText += NumberWords.words[digits2[0] * 10];
                                numbersText += NumberWords.words[digits2[1]];
                            }
                        }
                        break;

                    case 3:

                        int[] digits3 = GetDigits(i);
                        numbersText += NumberWords.words[digits3[0]];
                        numbersText += "hundred";
                        if (i % 100 != 0)
                        {
                            numbersText += "and";

                            if (digits3.Last() == 0)
                            {
                                numbersText += NumberWords.words[i - 100 * digits3[0]];
                            }
                            else
                            {
                                if (digits3[1] == 1) 
                                {
                                    numbersText += NumberWords.words[digits3[1] * 10 + digits3[2]];
                                }
                                else if (NumberWords.words.ContainsKey(digits3[1] * 10))
                                {
                                    numbersText += NumberWords.words[digits3[1] * 10];
                                    numbersText += NumberWords.words[digits3[2]];
                                }
                                else
                                {
                                    numbersText += NumberWords.words[digits3[2]];
                                }

                            }
                        }
                        break;

                    case 4:
                        int[] digits4 = GetDigits(i);
                        numbersText += NumberWords.words[digits4[0]];
                        numbersText += "thousand";
                        if (i % 1000 != 0)
                        {
                            if ((digits4[1] != 0) || (digits4[2] == 0) || (digits4[3] == 0))
                            {
                                numbersText += "and";
                                numbersText += NumberWords.words[digits4[1]];
                                numbersText += "hundred";
                            }
                            else
                            {
                                if (digits4[1] != 0)
                                {
                                    numbersText += NumberWords.words[digits4[1]];
                                    numbersText += "hundred";
                                }
                            }
                            if (i % 100 != 0)
                            {
                                numbersText += "and";

                                if (digits4.Last() == 0)
                                {
                                    numbersText += NumberWords.words[i - 100 * digits4[0]];
                                }
                                else
                                {
                                    if (NumberWords.words.ContainsKey(digits4[2] * 10))
                                    {
                                        numbersText += NumberWords.words[digits4[2] * 10];
                                        numbersText += NumberWords.words[digits4[3]];
                                    }
                                    else
                                    {
                                        numbersText += NumberWords.words[digits4[3]];
                                    }

                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            numbersText = numbersText.Trim(' ');
            Console.WriteLine(numbersText);
            return numbersText.Count();
        }

        private int CountNumberDigits(int number)
        {
            return number.ToString().ToCharArray().Count();
        }

        private int[] GetDigits(int number)
        {
            char[] charNumbers = number.ToString().ToCharArray();
            return Array.ConvertAll(charNumbers, c => (int)Char.GetNumericValue(c));
        }

        #endregion
    }

    class NumberWords
    {
        public static Dictionary<int, string> words = new Dictionary<int, string>()
        {
            {1,"one"},
            {2,"two"},
            {3,"three"},
            {4,"four"},
            {5,"five"},
            {6,"six"},
            {7,"seven"},
            {8,"eight"},
            {9,"nine"},
            {10,"ten"},
            {11,"eleven"},
            {12,"twelve"},
            {13,"thirteen"},
            {14,"fourteen"},
            {15,"fifteen"},
            {16,"sixteen"},
            {17,"seventeen"},
            {18,"eighteen"},
            {19,"nineteen"},
            {20,"twenty"},
            {30,"thirty"},
            {40,"forty"},
            {50,"fifty"},
            {60,"sixty"},
            {70,"seventy"},
            {80,"eighty"},
            {90,"ninety"},
        };
    }
}

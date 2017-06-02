using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class LargeSum : IProblem
    {
        private const string MENU_ENTRY = "Sum of Squares/Square of sum difference";
        private const int NUM_DIGITS = 50;
        private const int NUM_LINES = 100;

        private List<string> numbersStringList;

        #region Overrides

        public bool Run()
        {
            if (Introduction())
            {
                Console.Write("Result: ");
                foreach(var digit in ComputeResult())
                {
                    Console.Write(digit);
                }
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
            Console.WriteLine("Enter the number:");
            ReadNumber();
            return true;  
        }

        #endregion

        #region Private Methods

        private void ReadNumber()
        {
            numbersStringList = new List<string>();
            string lineRead = String.Empty;

            for (int i = 0; i < NUM_LINES; i++)
            {
                lineRead = Console.ReadLine();
                numbersStringList.Add(lineRead);
            }
        }

        private List<int> ConvertNumberToIntList(string number)
        {
            List<int> intList = new List<int>();
            char[] charArray = number.ToCharArray();
            foreach(char character in charArray)
            {
                intList.Add((int)char.GetNumericValue(character));
            }
            return intList;
        }

        private int[] ComputeResult()
        {
            List<List<int>> numbersList = new List<List<int>>();
            int[] result = new int[NUM_DIGITS+1];
            int totalColumn;

            foreach (string number in numbersStringList) 
            {
                numbersList.Add(ConvertNumberToIntList(number)); 
            }

            for (int i = NUM_DIGITS; i > 0 ; i--) 
            {
                totalColumn = 0;
                foreach (List<int> number in numbersList) 
                {
                    totalColumn += number.ElementAt(i-1); 
                }
                
                result[i] = totalColumn;
            }

            result = UpdateCarry(result);
            return result;
        }

        private int[] UpdateCarry(int[] number) 
        {
            int remainder;
            int carry;

            for (int i = number.Length-1; i > 0; i--)
            {
                remainder = number[i] % 10;
                carry = ComputeCarry(number[i],remainder);
                number[i] = remainder;
                number[i - 1] += carry;
            }
             return number;
        }

        private int ComputeCarry(int number,int remainder) 
        {
            int result;
            if (number < 10)
            {
                return 0;
            }
            else
            {
                result = number - remainder;
                result /= 10;
                return result;
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class LargestProductInSeries : IProblem
    {
        private const string MENU_ENTRY = "Largest Product In a Series";

        private const int MAX_DIGITS = 1000;
        private int serieLenght;
        private string number;

        #region Overrides

        public bool Run()
        {

            if (Introduction())
            {
                int currentIndex = 0;
                double result = 0;
                double maxValue = 0;

                while (currentIndex + serieLenght < MAX_DIGITS) 
                {
                    result = ReadNDigits(ref currentIndex);
                    if (result > maxValue) 
                    {
                        maxValue = result;
                    }
                }
                Console.WriteLine("Result: " + maxValue);
                return true;
            }
            else return false;
        }

        public string GetMenuEntry()
        {
            return MENU_ENTRY;
        }

        public bool Introduction()
        {
            Console.WriteLine("Enter the lenght of the series:");
            if (int.TryParse(Console.ReadLine(), out serieLenght))
            {
                Console.WriteLine("Enter the number:");
                number = ReadNumber();
                return true;
            }
            else return false;
        }

        #endregion

        #region Private Methods

        private string ReadNumber() 
        {
            string number = String.Empty;
            string lineRead = String.Empty;
            int totalLenght = 0;

            while (totalLenght < MAX_DIGITS) 
            {
                lineRead = Console.ReadLine();
                number += lineRead;
                totalLenght += lineRead.Length;
            }
            return number;
        }

        private double ReadNDigits(ref int currentIndex)
        {
            double result = 1;
            for (int i = currentIndex; i < currentIndex + serieLenght && i <= MAX_DIGITS; i++) 
            {
                result = result * int.Parse(number[i].ToString());
            }
            currentIndex++;
            return result;        
        }

        #endregion

    }
}

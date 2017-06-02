using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class LastPalindromeProduct : IProblem
    {
        private const string MENU_ENTRY = "Last Palindrome Product";
        int numberOfDigits;
        List<double> palindromesList;

        #region Overrides

        public bool Run()
        {
            if (Introduction())
            {
                double highestPalindrome;
                double highestNumberDigits = GetHighestNumberWithDigits(numberOfDigits);

                palindromesList = GetAllPalindromesProd(highestNumberDigits);
                highestPalindrome = palindromesList.Last();

                Console.WriteLine("Result: " + highestPalindrome);
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
            Console.WriteLine("Enter the number digits that each number of the product have:");
            if (int.TryParse(Console.ReadLine(), out numberOfDigits))
            {
                return true;
            }
            else return false;
        }

        #endregion

        #region Private Methods

        private bool IsPalindrome(double number)
        {
            List<char> digitsList = new List<char>();
            string strNumber = number.ToString();
            for (int i = 0; i < strNumber.Length/2; i++) 
            {
                if(strNumber[i] != strNumber[strNumber.Length-1-i])
                {
                    return false;
                }
            }
                return true;
        }

        private double GetHighestNumberWithDigits(int numDigits) 
        {
            return Math.Pow(10,numberOfDigits) - 1; 
        }

        private List<double> GetAllPalindromesProd(double highestNumberDigits) 
        {
            List<double> palindromesList = new List<double>();
            double prodResult;
            for (double firstProdNumber = highestNumberDigits; firstProdNumber > 0; firstProdNumber--) 
            {
                for (double secondProdNumber = highestNumberDigits; secondProdNumber > 0; secondProdNumber--) 
                {
                    prodResult = firstProdNumber * secondProdNumber;
                    if (IsPalindrome(prodResult))
                    {
                        palindromesList.Add(prodResult);
                    }
                }
            }
            palindromesList.Sort();
            return palindromesList;
        }

        #endregion
    }
}

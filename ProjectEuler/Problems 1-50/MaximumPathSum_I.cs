using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class MaximumPathSum_I : IProblem
    {

        private const string MENU_ENTRY = "Maximum Path Sum I";
        private const int PYRAMID_SIZE = 15;

        private Stack<int[]> pyramid;

        #region Overrides

        public bool Run()
        {
            pyramid = new Stack<int[]>();
            if (Introduction())
            {
                int total = ComputeBestPath();
                Console.WriteLine("Total Sum: " + total);
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
            string[] line;
            int[] intLine;
            Console.WriteLine("Enter pyramid: ");
            for (int i = 0; i < PYRAMID_SIZE; i++) 
            {
                line = Console.ReadLine().Split(' ');
                intLine = Array.ConvertAll(line, elem => int.Parse(elem));
                pyramid.Push(intLine);
            }
            return true;
        }

        #endregion

        #region Private Methods

        private int ComputeBestPath()
        {
            int total = 0;
            int[] currentLine;
            int[] newLine;
            int[] previousLine;
            int leftValue;
            int rightValue;

            for (int i = 0; i < PYRAMID_SIZE-1; i++) 
            {
                previousLine = pyramid.Pop();
                currentLine = pyramid.Peek();
                newLine = new int[currentLine.Length];
                for(int j = 0; j < currentLine.Length ; j++) 
                {
                    leftValue = currentLine[j] + previousLine[j];
                    rightValue = currentLine[j] + previousLine[j+1];
                    newLine[j] = Math.Max(leftValue, rightValue);
                }
                pyramid.Pop();
                pyramid.Push(newLine);

                //PrintLine(newLine);
                total = newLine[0];
            }
            return total;
        }

        private void PrintLine(int[] line)
        {
            for (int j = 0; j < line.Length; j++) 
                {
                    Console.Write(line[j] + " ");
                    
                }
                Console.WriteLine("");
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class LargestProductInGrid : IProblem
    {
        private const string MENU_ENTRY = "Largest Product in a Grid";
        private const int ADJENCY_LENGTH = 4;
        private int gridSize;
        private int[][] grid;

        #region Overrides

        public bool Run()
        {

            if (Introduction())
            {
                double higherProductAdjacentRight = AdjacentRight().Max();
                double higherProductAdjacentDown = AdjacentDown().Max();
                double higherProductAdjacentDiagonalRight = AdjacentDiagonalRight().Max();
                double higherProductAdjacentDiagonalLeft = AdjacentDiagonalLeft().Max();
                Console.WriteLine(Math.Max(Math.Max(higherProductAdjacentRight,higherProductAdjacentDown),Math.Max(higherProductAdjacentDiagonalLeft,higherProductAdjacentDiagonalRight)));
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
            Console.WriteLine("Enter size of the grid:");
            if (Int32.TryParse(Console.ReadLine(), out gridSize))
            {
                grid = new int[gridSize][];
                Console.WriteLine("Enter the grid:");
                if (ReadGrid())
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Private Methods

        private bool ReadGrid() 
        {   string[] strLine;
            int[] line;
            for (int i = 0; i < gridSize; i++) 
            {
                strLine = Console.ReadLine().Split(' ');
                line = Array.ConvertAll(strLine, x => int.Parse(x));
                grid[i] = line;
            }
            return true;
        }

        private List<double> AdjacentRight() 
        {
            List<double> productList = new List<double>();
            double product;
            for (int i = 0; i < gridSize; i++) 
            {
                for (int j = 0; j < gridSize; j++)
                {
                    product = 1;
                    for (int adjacentIterator = j; adjacentIterator < j + ADJENCY_LENGTH && j + ADJENCY_LENGTH <= gridSize; adjacentIterator++)
                    {
                         product *= grid[i][adjacentIterator];
                    }
                    productList.Add(product);
                }
            }
            return productList;
        }

        private List<double> AdjacentDown()
        {
            List<double> productList = new List<double>();
            double product;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    product = 1;
                    for (int adjacentIterator = i; adjacentIterator < i + ADJENCY_LENGTH && i + ADJENCY_LENGTH <= gridSize; adjacentIterator++)
                    {
                        product *= grid[adjacentIterator][j];
                    }
                    productList.Add(product);
                }
            }
            return productList;
        }

        private List<double> AdjacentDiagonalRight()
        {
            List<double> productList = new List<double>();
            double product;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    product = 1;
                    for (int adjacentIteratorX = j, adjacentIteratorY = i; adjacentIteratorX < j + ADJENCY_LENGTH && j + ADJENCY_LENGTH <= gridSize && adjacentIteratorY < i + ADJENCY_LENGTH && i + ADJENCY_LENGTH <= gridSize; adjacentIteratorX++,adjacentIteratorY++)
                    {
                        product *= grid[adjacentIteratorY][adjacentIteratorX];
                    }
                    productList.Add(product);
                }
            }
            return productList;
        }

        private List<double> AdjacentDiagonalLeft()
        {
            List<double> productList = new List<double>();
            double product;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    product = 1;
                    for (int adjacentIteratorX = j, adjacentIteratorY = i + ADJENCY_LENGTH - 1; adjacentIteratorX < j + ADJENCY_LENGTH && j + ADJENCY_LENGTH <= gridSize && adjacentIteratorY < i + ADJENCY_LENGTH && i + ADJENCY_LENGTH <= gridSize; adjacentIteratorX++, adjacentIteratorY--)
                    {
                        product *= grid[adjacentIteratorY][adjacentIteratorX];
                    }
                    productList.Add(product);
                }
            }
            return productList;
        }


        #endregion
    }
}

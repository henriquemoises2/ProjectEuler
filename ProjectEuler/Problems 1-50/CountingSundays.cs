using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class CountingSundays : IProblem
    {
        private const string MENU_ENTRY = "Counting Sundays";

        private DateTime startDate;
        private DateTime endDate;

        #region Overrides

        public bool Run()
        {
            if (Introduction())
            {
                int totalSundays = CountSundays();
                Console.WriteLine("Total Sundays: " + totalSundays);
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
            Console.WriteLine("Enter the starting date (dd MM yyyy): ");
            if(DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Enter the ending date (dd MM yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out endDate))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Private Methods

        private int CountSundays() 
        {
            int totalSundays = 0;
            DateTime iterDate = startDate;            
            while (iterDate < endDate) 
            {
                if (iterDate.DayOfWeek == DayOfWeek.Sunday) 
                {
                    totalSundays++;
                }
                iterDate = iterDate.AddMonths(1);
            }
            return totalSundays;
        }

        #endregion
    }
}

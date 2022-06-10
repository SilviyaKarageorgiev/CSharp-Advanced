using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    internal class DateModifier
    {

        private string firstDate;
        private string secondDate;

        
        public string FirstDate
        {
            get { return firstDate; }
            set { firstDate = value; }
        }
        public string SecondDate
        {
            get { return secondDate; }
            set { secondDate = value; }
        }

        public double CalculateDaysBetweenTwoDates(string first, string second)
        {
            int[] one = first.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] two = second.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            System.DateTime firstDate = new DateTime(one[0], one[1], one[2]);
            System.DateTime secondDate = new DateTime(two[0], two[1], two[2]);

            TimeSpan diff = secondDate.Subtract(firstDate);
            System.TimeSpan diff1 = secondDate - firstDate;
            double diff2 = (secondDate - firstDate).TotalDays;

            return Math.Abs(diff2);
            
        }
    }
}

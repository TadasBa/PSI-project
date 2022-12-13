using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
    public class SelectColor
    {
        private const int daysLimit1 = 1;
        private const int daysLimit2 = 3;
        private static int daysLeft;

        public static int GetDaysLeft(DateTime expiryDate, DateTime currentDate)
        {
            TimeSpan interval = expiryDate - currentDate;

            return (int) Math.Ceiling(interval.TotalDays);

        }

        public static string SetColor(DateTime expiryDate, DateTime currentDate)
        {
            daysLeft = GetDaysLeft(expiryDate, currentDate);


            if (daysLeft <= daysLimit1)
            {
                return "#FF0000";

            }
            else if (daysLeft <= daysLimit2)
            {
                return "#FFA500";

            }
            else
            {
                return "#00FF00";
            }
        }

        public static string DisplayDaysLeft(DateTime expiryDate, DateTime currentDate)
        {
            daysLeft = GetDaysLeft(expiryDate, currentDate);

            if (daysLeft <= 0)
            {
                return "Product expired";
            }
            else
            {
                return "Days left: " + daysLeft.ToString();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
    static class SelectColor
    {
        private const int daysLimit1 = 1;
        private const int daysLimit2 = 3;

        private static double GetDaysLeft(DateTime expiryDate)
        {
            TimeSpan interval = expiryDate - DateTime.Now;

            return interval.TotalDays;

        }

        public static String SetColor(DateTime expiryDate)
        {
            double daysLeft = GetDaysLeft(expiryDate);

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
    }
}

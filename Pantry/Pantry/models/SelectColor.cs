﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
    static class SelectColor
    {
        private const int daysLimit1 = 1;
        private const int daysLimit2 = 3;
        private static int daysLeft;

        private static int GetDaysLeft(DateTime expiryDate)
        {
            TimeSpan interval = expiryDate - DateTime.Now;

            return (int) Math.Ceiling(interval.TotalDays);

        }

        public static String SetColor(DateTime expiryDate)
        {
            daysLeft = GetDaysLeft(expiryDate);


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

        public static String DisplayDaysLeft(DateTime expiryDate)
        {
            if(daysLeft <= 0)
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

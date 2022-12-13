using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Pantry.models
{
    static class Notification
    {
        public static NotificationRequest ProductExpirationNotification(DateTime expiryDate, string titleName, string defaultMessage = "Check your fridge")
        {
            string message;
            int daysLimit1 = 1;
            int daysLimit2 = 3;
            Random random = new Random();

            if (titleName.Equals("WARNING"))
            {
                message = defaultMessage;
            }

            else if (SelectColor.GetDaysLeft(expiryDate, DateTime.Now) < daysLimit1)
            {
                message = "You have an expired product";
            }

            else if (SelectColor.GetDaysLeft(expiryDate, DateTime.Now) >= daysLimit1 && SelectColor.GetDaysLeft(expiryDate, DateTime.Now) <= daysLimit2)
            {
                message = "Your product will expire soon";
            }

            else
            {
                return null;
            }

            NotificationRequest notification = new NotificationRequest
            {
                Description = message,
                Title = titleName,
                NotificationId = random.Next(1, 10)
            };

            return notification;
        }
    }
}
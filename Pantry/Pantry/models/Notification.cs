using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
    static class Notification
    {

        public static NotificationRequest ProductExpirationNotification(DateTime expiryDate)
        {
            string message;
            int daysLimit1 = 1;
            int daysLimit2 = 3;
            Random random = new Random();

            if (SelectColor.GetDaysLeft(expiryDate) < daysLimit1)
            {
                message = "You have an expired product";
            }

            else if (SelectColor.GetDaysLeft(expiryDate) >= daysLimit1 && SelectColor.GetDaysLeft(expiryDate) <= daysLimit2)
            {
                message = "Your product will expire soon";
            }

            else
            {
                return null;
            }

            NotificationRequest notification = new NotificationRequest
            {
                BadgeNumber = 5,
                Description = message,
                Title = "Notification",
                NotificationId = random.Next(1, 10)
            };

            return notification;
        }
    }
}
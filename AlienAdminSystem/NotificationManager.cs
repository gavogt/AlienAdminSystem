using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class NotificationManager
    {
        private readonly List<INotificationObserver> observers = new();

        // Subscribe to notifications
        public void RegisterObserver(INotificationObserver observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }

        // Unsubscribe from notifications
        public void UnregisterObserver(INotificationObserver observer)
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }

        // Notify all observers
        public async Task NotifyAsync(NotificationMessage message)
        {
            foreach (var observer in observers)
            {
                await observer.OnNotificationReceived(message);
            }

        }
    }
}

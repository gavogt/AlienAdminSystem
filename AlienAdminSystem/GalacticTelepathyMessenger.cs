using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class GalacticTelepathyMessenger : INotificationObserver
    {
        // Action to be executed when a notification is received
        private readonly Action<NotificationMessage> _onNotification;

        public GalacticTelepathyMessenger(Action<NotificationMessage> onNotification)
        {
            _onNotification = onNotification;

        }

        // Reacts to a notification by executing the provided action
        public Task OnNotificationReceived(NotificationMessage message)
        {
            _onNotification?.Invoke(message);
            return Task.CompletedTask;
        }
    }
}

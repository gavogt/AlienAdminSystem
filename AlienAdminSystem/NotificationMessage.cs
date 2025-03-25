using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class NotificationMessage
    {
        // Payload for the message
        public string Title { get; set; } = String.Empty;
        public string Content { get; set; } = String.Empty; 
        public DateTime Timestamp { get; set; } = DateTime.Now;

    }
}

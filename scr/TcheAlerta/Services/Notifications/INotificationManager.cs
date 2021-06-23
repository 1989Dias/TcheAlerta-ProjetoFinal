using System;
using System.Collections.Generic;
using System.Text;

namespace TcheAlerta.Services
{
    public interface INotificationManager
    {
        event EventHandler NotificationReceived;
        void Initialize();
        void SendNotification(string title, string message, string id, DateTime? notifyTime = null);
        void ReceiveNotification(string id, string title, string message);
    }
}

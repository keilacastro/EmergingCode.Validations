using System.Collections.Generic;
using System.Linq;

namespace EmergingCode.Validations
{
    public abstract class Validatable
    {
        private List<Notification> _notifications;

        public bool HasNotifications => _notifications.Any(x => x != null);
        public IEnumerable<Notification> Notifications => _notifications;

        public bool IsValid()
        {
            CreateNotificationListIfNonExists();
            
            var notifications = GetNotificationsFromValidations();
            if (notifications != null)
                _notifications.AddRange(notifications);

            return !HasNotifications;
        }

        public string StringfyNotifications(string separator = "|")
        {
            CreateNotificationListIfNonExists();

            return HasNotifications ?
                   string.Join(separator, _notifications.Select(x => x.Message)) :
                   string.Empty;
        }

        public void Notify(string message)
        {
            CreateNotificationListIfNonExists();
            _notifications.Add(new Notification(message));
        }

        public void Notify(IEnumerable<Notification> notifications)
        {
            CreateNotificationListIfNonExists();

            foreach (var item in notifications)
                if (item != null) _notifications.Add(item);
        }

        protected virtual IEnumerable<Notification> Specifications() =>
            null;

        private IEnumerable<Notification> GetNotificationsFromValidations() =>
            Specifications()?.Where(x => x != null);

        private void CreateNotificationListIfNonExists() =>
            _notifications = _notifications ?? new List<Notification>();
    }
}

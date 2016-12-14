using System;

namespace EmergingCode.Validations
{
    public sealed class Notification
    {
        public string Key { get; private set; }
        public string Message { get; private set; }
        public DateTime OccuredOn { get; private set; }

        public Notification(string message)
        {
            OccuredOn = DateTime.Now;
            Message = message;
        }

        public Notification(string message, string key)
        {
            Message = message;
            Key = key;
        }
    }
}
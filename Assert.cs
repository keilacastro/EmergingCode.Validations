using System;
using System.Text.RegularExpressions;

namespace EmergingCode.Validations
{
    public class Assert
    {
        public static Notification True(bool assertion, string message, string id = "")
        {
            if (assertion == false) return new Notification(id, message);
            else return null;
        }

        public static Notification False(bool assertion, string message, string id = "")
        {
            if (assertion == true) return new Notification(id, message);
            else return null;
        }

        public static Notification Equals(string expected, string actual, string message, string id = "")
        {
            if (expected != actual) return new Notification(id, message);
            else return null;
        }

        public static Notification Length(string stringValue, int minimum, int maximum, string message, string id = "")
        {
            var length = stringValue?.Trim().Length;

            return (length < minimum || length > maximum)
                ? new Notification(id, message)
                : null;
        }

        public static Notification Range(int value, int minimum, int maximum, string message, string id = "")
        {
            return (value < minimum || value > maximum)
                ? new Notification(id, message)
                : null;
        }

        public static Notification Matches(string pattern, string stringValue, string message, string id = "")
        {
            var regex = new Regex(pattern);

            return (!regex.IsMatch(stringValue))
                ? new Notification(id, message)
                : null;
        }

        public static Notification NotEmpty(string stringValue, string message, string id = "")
        {
            return (string.IsNullOrEmpty(stringValue))
                ? new Notification(id, message)
                : null;
        }

        public static Notification NotNull(object object1, string message, string id = "")
        {
            return (object1 == null)
                ? new Notification(id, message)
                : null;
        }

        public static Notification IsNull(object object1, string message, string id = "")
        {
            return (object1 != null)
                ? new Notification(id, message)
                : null;
        }

        public static Notification IsGreaterThan(int value1, int value2, string message, string id = "")
        {
            return (!(value1 > value2))
                ? new Notification(id, message)
                : null;
        }

        public static Notification IsGreaterThan(decimal value1, decimal value2, string message, string id = "")
        {
            return (!(value1 > value2))
                ? new Notification(id, message)
                : null;
        }

        public static Notification IsGreaterOrEqualThan(int value1, int value2, string message, string id = "")
        {
            return (!(value1 >= value2))
                ? new Notification(id, message)
                : null;
        }

        public static Notification RegexMatch(string value, string regex, string message, string id = "")
        {
            return (!Regex.IsMatch(value, regex, RegexOptions.IgnoreCase))
                ? new Notification(id, message)
                : null;
        }

        public static Notification EmailIsValid(string email, string message, string id = "")
        {
            var emailRegex =
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            return (!Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase))
                ? new Notification(id, message)
                : null;
        }

        public static Notification DateIsValid(string data, string message, string id = "")
        {
            var dataRegex = @"(^(((0[1-9]|1[0-9]|2[0-8])[\/](0[1-9]|1[012]))|((29|30|31)[\/](0[13578]|1[02]))|((29|30)[\/](0[4,6,9]|11)))[\/](19|[2-9][0-9])\d\d$)|(^29[\/]02[\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)";

            return (!Regex.IsMatch(data, dataRegex, RegexOptions.IgnoreCase))
                ? new Notification(id, message)
                : null;
        }

        public static Notification UrlIsValid(string url, string message, string id = "")
        {
            // Do not validate if no URL is provided
            // You can call AssertNotEmpty before this if you want
            if (String.IsNullOrEmpty(url))
                return null;

            var regex = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";

            return (!Regex.IsMatch(url, regex, RegexOptions.IgnoreCase))
                ? new Notification(id, message)
                : null;
        }
    }
}
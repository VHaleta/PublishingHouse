using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.Helpers
{
    public static class Converter
    {
        public static string IntToString(int num) => (num == 0) ? "null" : num.ToString();
        public static int StringToInt(string str) => (String.IsNullOrEmpty(str) || str == "null") ? 0 : int.Parse(str);
        public static string StringToDatabase(string str) => String.IsNullOrEmpty(str) ? "null" : $"'{str}'";
        public static string StringToDataBox(string str) => String.IsNullOrEmpty(str) ? "null" : str.ToString();
        public static string DataToString(string str) => (String.IsNullOrEmpty(str) || str == "null") ? null : str;
        public static string DataToComboBox(string str) => (str == null || str.ToString() == "null") ? null : str;
        public static DateTime DataToDateTime(string str) => (String.IsNullOrEmpty(str) || str == "null") ? new DateTime() : DateTime.Parse(str);
        public static string DateTimeToDatabase(DateTime date) => (date == DateTime.MinValue) ? "null" : $"'{date.ToString("dd.MM.yyyy")}'";
    }
}

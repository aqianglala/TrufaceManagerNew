using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TrufaceManager
{
    public class ValidTimeStartConverter : IValueConverter
    {
        private Dictionary<string, string> originalValuePairs = new Dictionary<string, string>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string validTime = value.ToString();
                string[] split = validTime.Split(',');
                string MonStart = split[1].Split('=')[0];
                if (!originalValuePairs.ContainsKey(parameter.ToString()))
                {
                    originalValuePairs.Add(parameter.ToString(), validTime);
                } else
                {
                    originalValuePairs[parameter.ToString()] = validTime;
                }
                return MonStart;
                //string MonEnd = split[1].Split('=')[1];
                //return System.Convert.ToDateTime(value.ToString());
            }
            return "00:00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is DateTime?)
                {
                    string start = ((DateTime)value).ToString("HH:mm:ss");
                    string originalValue = originalValuePairs[parameter.ToString()];
                    string[] split = originalValue.Split(',');
                    string newValue = $"{split[0]},{start}={split[1].Split('=')[1]}";
                    originalValuePairs[parameter.ToString()] = newValue;
                    return newValue;
                }
            }
            return null;
        }
    }
}

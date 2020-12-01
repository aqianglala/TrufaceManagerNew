using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TrufaceManager
{
    public class ValidTimeIsEnabledConverter : IValueConverter
    {
        private Dictionary<string, string> originalValuePairs = new Dictionary<string, string>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string validTime = value.ToString();
                string[] split = validTime.Split(',');
                int isEnabled = int.Parse(split[0]);
                
                if (!originalValuePairs.ContainsKey(parameter.ToString()))
                {
                    originalValuePairs.Add(parameter.ToString(), validTime);
                }
                else
                {
                    originalValuePairs[parameter.ToString()] = validTime;
                }
                return isEnabled == 1;
                //string MonStart = split[1].Split('=')[0];
                //string MonEnd = split[1].Split('=')[1];
                //return System.Convert.ToDateTime(value.ToString());
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is bool)
                {
                    int isEnabled = (bool)value ? 1 : 0;
                    string originalValue = originalValuePairs[parameter.ToString()];
                    string[] split = originalValue.Split(',');
                    string newValue = $"{isEnabled},{split[1]}";
                    originalValuePairs[parameter.ToString()] = newValue;
                    return newValue;
                }
            }
            return null;
        }
    }
}

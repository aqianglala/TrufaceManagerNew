using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TrufaceManager
{
    public class IsEnabled4ClearBtnConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //string[] inputs = Array.ConvertAll(values, x => x == null ? "" : x.ToString());
            string[] inputs = Array.ConvertAll(values, x =>
            {
                string str1 = x == null ? "" : x.ToString();
                if ("False".Equals(str1))
                {
                    return "";
                } else
                {
                    return str1;
                }
            });
            return inputs.Any(x => !string.IsNullOrEmpty((string)x));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

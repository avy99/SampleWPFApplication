using System;
using System.Globalization;
using System.Windows.Data;
using SampleWPFApplication.Models;

namespace SampleWPFApplication.Converters
{
    public class MultipleParamterValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var stu = new Student();
            stu.Email = values[0].ToString();
            stu.Name = values[1].ToString();
            if (values.Length == 3 && int.TryParse(values[2].ToString(), out var x)) stu.Id = x;
            return stu;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Windows.Data;


namespace CodesControl.Secondary
{
    [ValueConversion(typeof(object), typeof(string))]
    public class TypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            // Возвращаем строку в формате 123.456.789 руб.
            return changeTitle(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }

        private string changeTitle(Object _value)
        {
            var str = (string)_value;

            switch (str)
            {
                case "S": str = "Студент"; break;
                case "Z": str = "Заочник"; break;
                case "V": str = "Выпускник"; break;
                default: str = "Не определено"; break;
            }

            return str;
        }
    }
}

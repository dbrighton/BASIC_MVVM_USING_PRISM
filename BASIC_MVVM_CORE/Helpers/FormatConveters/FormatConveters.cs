using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace BASIC_MVVM_CORE.Helpers.FormatConveters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var aBool = value as Boolean?;

            if (aBool == null) return Visibility.Visible;
            if ((bool)aBool) return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }


    public class InversBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var aBool = value as Boolean?;

            if (aBool == null) return Visibility.Collapsed;
            if ((bool)aBool) return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

}

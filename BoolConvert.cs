﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CarRent.MobileApp
{
    public class BoolConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
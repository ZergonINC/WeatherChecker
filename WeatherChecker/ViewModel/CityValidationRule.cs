using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WeatherChecker.ViewModel
{
    class CityValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var city = value as string;

            if (Regex.IsMatch(city, @"^[a-zA-Z]+(-[a-zA-Z]+)*$"))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Название города должно быть только на английском языке." +
                "Например: London, Los-Angeles");
        }
    }
}

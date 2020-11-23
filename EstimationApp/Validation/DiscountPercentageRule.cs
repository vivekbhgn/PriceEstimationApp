using System;
using System.Globalization;
using System.Windows.Controls;

namespace EstimationApp.Validation
{
    public class DiscountPercentageRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public DiscountPercentageRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int discount = 0;

            try
            {
                if (((string)value).Length > 0)
                    discount = Int32.Parse((String)value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Illegal characters or {e.Message}");
            }

            if ((discount < Min) || (discount > Max))
            {
                return new ValidationResult(false,
                  $"Please enter discount in the range: {Min}-{Max}.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
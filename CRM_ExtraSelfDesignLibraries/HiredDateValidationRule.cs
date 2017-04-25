using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CRM_ExtraSelfDesignLibraries
{
    public class HiredDateValidationRule : ValidationRule
    {
        private string _errorMessage;
       
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
      
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            DateTime date = DateTime.Now;
            string inputString = (value ?? string.Empty).ToString();
            if (String.IsNullOrEmpty(inputString))
            {
                result = new ValidationResult(false, this.ErrorMessage);
            }
            try
            {
                date = DateTime.Parse(inputString);
            }
            catch (FormatException ex)
            {
                result = new ValidationResult(false, this.ErrorMessage);
            }
            return result;
        }
    }
}

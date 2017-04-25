using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CRM_ExtraSelfDesignLibraries
{
    public class BirthDateValidationRule : ValidationRule
    {
        private string _errorMessage;       
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime date = DateTime.Now;
            DateTime MinDate = DateTime.Now.AddYears(-20);
            DateTime MaxDate = DateTime.Now.AddYears(-40);
            ValidationResult result = new ValidationResult(true, null);
            string inputString = (value ?? string.Empty).ToString();
            if (String.IsNullOrEmpty(inputString))
            {
                result = new ValidationResult(false, this.ErrorMessage);
            }
            try
            {
                date = DateTime.Parse(inputString);
            }catch (FormatException ex)
            {
                result = new ValidationResult(false, this.ErrorMessage);
            }
            if(date >= MinDate || date <= MaxDate)
            {
                result = new ValidationResult(false, this.ErrorMessage);
            }
            return result;
        }
    }
}

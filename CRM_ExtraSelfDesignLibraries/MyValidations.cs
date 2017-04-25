using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CRM_ExtraSelfDesignLibraries
{
    public class MyValidations
    {
        public bool IsValidString(object value)
        {
            string inputString = (value ?? string.Empty).ToString();
            if (inputString.Length < 3 || inputString.Length > 50 || String.IsNullOrEmpty(inputString))
            {
                return false;
            }
            return true;
        }
        public bool IsValidPostalCode(object value)
        {
            Regex regexPostalcode = new Regex("[abceghjklmnprstvxyABCEGHJKLMNPRSTVXY][0-9][abceghjklmnprstvwxyzABCEGHJKLMNPRSTVWXYZ] ?[0-9][abceghjklmnprstvwxyzABCEGHJKLMNPRSTVWXYZ][0-9]");
            string inputString = (value ?? string.Empty).ToString();
            if (inputString.Length < 6 || inputString.Length > 7 || String.IsNullOrEmpty(inputString) || !regexPostalcode.IsMatch(inputString))
            {
                return false;
            }
            return true;
        }
        public bool IsValidEmail(object value)
        {
            string inputString = (value ?? string.Empty).ToString();
            try
            {
                MailAddress m = new MailAddress(inputString);
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }
        public bool IsValiPhone(object value)
        {
            string inputString = (value ?? string.Empty).ToString();
            Regex regexPhone = new Regex(@"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}");
            if (inputString.Length < 0 || inputString.Length > 12 || String.IsNullOrEmpty(inputString) || !regexPhone.IsMatch(inputString))
            {
                return false;
            }
            return true;

        }
        public bool IsValidUsername(object value)
        {
            string inputString = (value ?? string.Empty).ToString();
            Regex regexUsername = new Regex(@"^[a - zA - Z][a - zA - Z0 - 9]{ 4, 12 }$");
            if (inputString.Length < 4 || inputString.Length > 12 || String.IsNullOrEmpty(inputString) || !regexUsername.IsMatch(inputString))
            {
                return false;
            }
            return true;
        }
        public bool IsValidPassword(object value)
        {
            string inputString = (value ?? string.Empty).ToString();        
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(inputString))
            {              
                return false;
            }
            else if (!hasUpperChar.IsMatch(inputString))
            {              
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(inputString))
            {               
                return false;
            }
            else if (!hasNumber.IsMatch(inputString))
            {                
                return false;
            }

            else if (!hasSymbols.IsMatch(inputString))
            {                
                return false;
            }
            return true;

        }
        public bool IsNullOrEmptyEntry(object value)
        {
            string inputString = (value ?? string.Empty).ToString();
            if (String.IsNullOrEmpty(inputString))
            {
                return true;
            }
            return false;
        }
        public bool IsValidBirthDay(object value)
        {
            string inputString = (value ?? string.Empty).ToString();
            DateTime date;
            DateTime MinDate = DateTime.Now.AddYears(-20);
            DateTime MaxDate = DateTime.Now.AddYears(-40);
            try
            {
                date = DateTime.Parse(inputString);
            }
            catch (FormatException ex)
            {
                return false;
            }
            if (date >= MinDate || date <= MaxDate)
            {
                return false;
            }
            return true;
        }
        public bool IsValidHiredDay(object value)
        {
            string inputString = (value ?? string.Empty).ToString();
            DateTime date;
            DateTime ValidBirthDate = DateTime.Now;
            try
            {
                date = DateTime.Parse(inputString);
            }
            catch (FormatException ex)
            {
                return false;
            }
            if (date > ValidBirthDate)
            {
                return false;
            }
            return true;
        }
    }
}

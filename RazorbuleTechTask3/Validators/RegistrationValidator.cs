using System.Text.RegularExpressions;

namespace RazorbuleTechTask3.Validators
{
    public static class RegistrationValidator
    {
        public static bool Validate(this string registration)
        {
            Regex regex = new Regex("^[a-zA-Z]{2}[0-9]{2} [a-zA-Z]{3}$", RegexOptions.IgnoreCase);
            return regex.IsMatch(registration);
        }
    }
}

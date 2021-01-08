using System.ComponentModel.DataAnnotations;

namespace Quiz1.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string _allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            _allowedDomain = allowedDomain;
        }

        public override bool IsValid(object value)
        {
            string[] strings = value.ToString().Split('@');

            var allowedDomainToUpper = _allowedDomain.ToUpper();

            return strings[1].ToUpper().Equals(allowedDomainToUpper);
        }
    }
}

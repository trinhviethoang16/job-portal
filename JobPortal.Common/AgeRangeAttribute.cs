using System.ComponentModel.DataAnnotations;

namespace JobPortal.Common
{
    public class AgeRangeAttribute : ValidationAttribute
    {
        private readonly string _minAgePropertyName;

        public AgeRangeAttribute(string minAgePropertyName)
        {
            _minAgePropertyName = minAgePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var maxAgeProperty = validationContext.ObjectType.GetProperty(validationContext.MemberName);
            var minAgeProperty = validationContext.ObjectType.GetProperty(_minAgePropertyName);

            if (maxAgeProperty != null && minAgeProperty != null)
            {
                var maxAgeValue = maxAgeProperty.GetValue(validationContext.ObjectInstance, null);
                var minAgeValue = minAgeProperty.GetValue(validationContext.ObjectInstance, null);

                if (maxAgeValue != null && minAgeValue != null && (byte)maxAgeValue <= (byte)minAgeValue)
                {
                    return new ValidationResult("Max age must be greater than Min age.");
                }
            }

            return ValidationResult.Success;
        }
    }
}

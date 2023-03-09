namespace EMS.Common.ValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CurrentYearMaxValueAttribute : ValidationAttribute
    {
        public CurrentYearMaxValueAttribute(int minYear)
        {
            this.MinYear = minYear;
            this.ErrorMessage = $"Date of Birth should be between {minYear} and {DateTime.UtcNow.Year}.";
        }

        public int MinYear { get; }

        public override bool IsValid(object value)
        {
            if (value is int intValue)
            {
                if (intValue <= DateTime.UtcNow.Year && intValue >= this.MinYear)
                {
                    return true;
                }
            }

            if (value is DateTime dateTimeValue)
            {
                if (dateTimeValue.Year <= DateTime.UtcNow.Year && dateTimeValue.Year >= this.MinYear)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

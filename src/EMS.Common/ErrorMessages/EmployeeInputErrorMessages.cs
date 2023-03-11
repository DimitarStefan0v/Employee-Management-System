namespace EMS.Common.ErrorMessages
{
    /// <summary>
    /// Messages for Employee Input Model.
    /// </summary>
    public static class EmployeeInputErrorMessages
    {
        /// <summary>
        /// First Name Messages.
        /// </summary>
        public const string DisplayFirstName = "First Name";

        public const string FirstNameRequired = "The First Name is required";

        public const string FirstNameMinLength = "The First Name must be at least 2 characters long";

        public const string FirstNameMaxLength = "The First Name can't be more than 50 characters long";

        public const string DuplicateNames = "There is already a employee with the same first and last name";

        /// <summary>
        /// Last Name Messages.
        /// </summary>
        public const string DisplayLastName = "Last Name";

        public const string LastNameRequired = "The Last Name is required";

        public const string LastNameMinLength = "The Last Name must be at least 2 characters long";

        public const string LastNameMaxLength = "The Last Name can't be more than 50 characters long";

        /// <summary>
        /// Email Adress Messages.
        /// </summary>
        public const string DisplayEmail = "Email Address";

        public const string EmailRequired = "The Email Address is required";

        public const string EmailValidation = "Invalid Email Address";

        /// <summary>
        /// Phone Number Messages.
        /// </summary>
        public const string DisplayPhoneNumber = "Phone Number";

        public const string PhoneNumberRequired = "The Phone Number is required";

        public const string PhoneNumberValidation = "Invalid Phone Number";

        /// <summary>
        /// Date Of Birth Messages.
        /// </summary>
        public const string DisplayDateOfBirth = "Date Of Birth";

        public const string DateOfBirthRequired = "The Date Of Birth is required";

        /// <summary>
        /// Monthly Salary Messages.
        /// </summary>
        public const string DisplayMonthlySalary = "Monthly Salary";

        public const string MonthlySalaryRequired = "The Monthly Salary is required";

        public const string MonthlySalaryRange = "The Monthly Salary must be between 600 and 10000 euro";
    }
}

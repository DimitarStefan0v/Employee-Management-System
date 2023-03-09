namespace EMS.Web.ViewModels.Employees
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EMS.Common.ErrorMessages;
    using EMS.Common.ValidationAttributes;

    public abstract class BaseEmployeeInputModel
    {
        [Display(Name = EmployeeInputErrorMessages.DisplayFirstName)]
        [Required(ErrorMessage = EmployeeInputErrorMessages.FirstNameRequired)]
        [MinLength(2, ErrorMessage = EmployeeInputErrorMessages.FirstNameMinLength)]
        [MaxLength(50, ErrorMessage = EmployeeInputErrorMessages.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Display(Name = EmployeeInputErrorMessages.DisplayLastName)]
        [Required(ErrorMessage = EmployeeInputErrorMessages.LastNameRequired)]
        [MinLength(2, ErrorMessage = EmployeeInputErrorMessages.LastNameMinLength)]
        [MaxLength(50, ErrorMessage = EmployeeInputErrorMessages.LastNameMaxLength)]
        public string LastName { get; set; }

        [Display(Name = EmployeeInputErrorMessages.DisplayEmail)]
        [Required(ErrorMessage = EmployeeInputErrorMessages.EmailRequired)]
        [EmailAddress(ErrorMessage = EmployeeInputErrorMessages.EmailValidation)]
        public string Email { get; set; }

        [Display(Name = EmployeeInputErrorMessages.DisplayPhoneNumber)]
        [Required(ErrorMessage = EmployeeInputErrorMessages.PhoneNumberRequired)]
        [DataType(DataType.PhoneNumber, ErrorMessage = EmployeeInputErrorMessages.PhoneNumberValidation)]
        public string PhoneNumber { get; set; }

        [Display(Name = EmployeeInputErrorMessages.DisplayDateOfBirth)]
        [Required(ErrorMessage = EmployeeInputErrorMessages.DateOfBirthRequired)]
        [DataType(DataType.Date, ErrorMessage = EmployeeInputErrorMessages.DateOfBirthRequired)]
        [CurrentYearMaxValueAttribute(1900)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = EmployeeInputErrorMessages.DisplayMonthlySalary)]
        [Required(ErrorMessage = EmployeeInputErrorMessages.MonthlySalaryRequired)]
        [Range(600, 20000, ErrorMessage = EmployeeInputErrorMessages.MonthlySalaryRange)]
        public double MonthlySalary { get; set; }
    }
}

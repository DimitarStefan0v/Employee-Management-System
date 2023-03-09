namespace EMS.Web.ViewModels.Employees
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateEmployeeInputModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The First Name is required")]
        [MinLength(2, ErrorMessage = "The First Name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "The First Name can't be more than 50 characters long")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The Last Name is required")]
        [MinLength(2, ErrorMessage = "The Last Name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "The Last Name can't be more than 50 characters long")]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "The Phone Number is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "The Date Of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Monthly Salary")]
        [Required(ErrorMessage = "The Monthly Salary is required")]
        [Range(600, 20000, ErrorMessage = "The Monthly Salary must be between 600 and 10000 leva")]
        public double MonthlySalary { get; set; }
    }
}

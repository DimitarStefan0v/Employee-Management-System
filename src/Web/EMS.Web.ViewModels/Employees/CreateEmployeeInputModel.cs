namespace EMS.Web.ViewModels.Employees
{
    using System;

    public class CreateEmployeeInputModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double MonthlySalary { get; set; }
    }
}

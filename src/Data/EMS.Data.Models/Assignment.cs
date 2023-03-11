namespace EMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using EMS.Data.Common.Models;

    public class Assignment : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public bool Finished { get; set; }

        [ForeignKey(nameof(Employee))]
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}

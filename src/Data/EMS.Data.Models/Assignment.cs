namespace EMS.Data.Models
{
    using System;
    using System.Collections.Generic;

    using EMS.Data.Common.Models;

    public class Assignment : BaseDeletableModel<int>
    {
        public Assignment()
        {
            this.Employees = new HashSet<Employee>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}

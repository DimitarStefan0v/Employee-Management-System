namespace EMS.Data.Models
{
    using EMS.Data.Common.Models;

    public class EmployeeAssignment : BaseDeletableModel<int>
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int AssignmentId { get; set; }

        public Assignment Assignment { get; set; }

        public bool Finished { get; set; }
    }
}

namespace EMS.Web.ViewModels.Assignments
{
    using System;

    using EMS.Data.Models;
    using EMS.Services.Mapping;

    public class AssignmentsViewModel : IMapFrom<Assignment>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public DateTime DueDate { get; set; }
    }
}

namespace EMS.Web.ViewModels.Assignments
{
    using EMS.Data.Models;
    using EMS.Services.Mapping;

    public class AssignmentsViewModel : IMapFrom<Assignment>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}

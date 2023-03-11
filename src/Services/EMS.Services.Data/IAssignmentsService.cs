namespace EMS.Services.Data
{
    using System.Threading.Tasks;

    using EMS.Web.ViewModels.Assignments;

    public interface IAssignmentsService
    {
        Task CreateAsync(CreateAssignmentInputModel input, string userId);

        bool CheckIfAssignmentExist(string title);
    }
}

namespace EMS.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EMS.Web.ViewModels.Assignments;

    public interface IAssignmentsService
    {
        Task CreateAsync(CreateAssignmentInputModel input, string userId);

        Task UpdateAsync(int id, EditAssignmentInputModel input);

        IEnumerable<T> GetAll<T>(string sort, int page, int itemsPerPage);

        T GetById<T>(int id);

        bool CheckIfAssignmentExist(string title);
    }
}

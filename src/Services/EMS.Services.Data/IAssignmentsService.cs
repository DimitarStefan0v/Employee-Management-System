namespace EMS.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EMS.Web.ViewModels.Assignments;

    public interface IAssignmentsService
    {
        Task CreateAsync(CreateAssignmentInputModel input, string userId);

        Task UpdateAsync(int id, EditAssignmentInputModel input);

        Task DeleteAsync(int id);

        IEnumerable<T> GetAll<T>(string sort, int page, int itemsPerPage);

        IEnumerable<T> GetAllPending<T>(string sort, int page, int itemsPerPage);

        IEnumerable<T> GetAllCompleted<T>(string sort, int page, int itemsPerPage);

        IEnumerable<T> GetAllPendingAssignmentsForDropDown<T>();

        T GetById<T>(int id);

        bool CheckIfAssignmentExist(string title);

        Task AssignToEmployee(int employeeId, int assignmentId);

        Task CompleteAssignment(int id);
    }
}

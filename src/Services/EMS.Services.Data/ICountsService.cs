namespace EMS.Services.Data
{
    public interface ICountsService
    {
        int GetEmployeesCount();

        int GetEmployeesCountByName(string name);

        int GetAssignmentsCount();

        int GetPendingAssignments();

        int GetCompletedAssignments();
    }
}

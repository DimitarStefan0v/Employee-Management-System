namespace EMS.Services.Data
{
    public interface ICountsService
    {
        int GetEmployeesCount();

        int GetEmployeesCountByName(string name);
    }
}

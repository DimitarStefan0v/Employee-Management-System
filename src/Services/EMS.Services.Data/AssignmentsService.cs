namespace EMS.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EMS.Data.Common.Repositories;
    using EMS.Data.Models;
    using EMS.Services.Mapping;
    using EMS.Web.ViewModels.Assignments;

    public class AssignmentsService : IAssignmentsService
    {
        private readonly IDeletableEntityRepository<Assignment> assignmentsRepository;
        private readonly IDeletableEntityRepository<Employee> employeesRepository;

        public AssignmentsService(
            IDeletableEntityRepository<Assignment> assignmentsRepository,
            IDeletableEntityRepository<Employee> employeesRepository)
        {
            this.assignmentsRepository = assignmentsRepository;
            this.employeesRepository = employeesRepository;
        }

        /// <summary>
        /// Create Assignment and add it to Database.
        /// </summary>
        public async Task CreateAsync(CreateAssignmentInputModel input, string userId)
        {
            var assignment = new Assignment
            {
                Title = input.Title.Trim(),
                Description = input.Description.Trim(),
                StartDate = input.StartDate,
                DueDate = input.DueDate,
                Finished = false,
                AddedByUserId = userId,
            };

            await this.assignmentsRepository.AddAsync(assignment);
            await this.assignmentsRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Check If Assignment with the same Title exists and it's not finished.
        /// </summary>
        public bool CheckIfAssignmentExist(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return false;
            }

            return this.assignmentsRepository
                .AllAsNoTracking()
                .Any(x => x.Title.ToLower() == title.ToLower().Trim() && x.Finished == false);
        }

        /// <summary>
        /// Get All Assignments.
        /// </summary>
        public IEnumerable<T> GetAll<T>(string sort, int page, int itemsPerPage)
        {
            var query = this.assignmentsRepository
                            .AllAsNoTracking()
                            .AsQueryable();

            SortEmployees(ref sort, ref query);

            return query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        /// <summary>
        /// Get Assignment by Id.
        /// </summary>
        public T GetById<T>(int id)
        {
            return this.assignmentsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
        }

        /// <summary>
        /// Update Assignment.
        /// </summary>
        public async Task UpdateAsync(int id, EditAssignmentInputModel input)
        {
            var assignment = this.assignmentsRepository.All().FirstOrDefault(x => x.Id == id);
            if (assignment != null)
            {
                assignment.Title = input.Title.Trim();
                assignment.Description = input.Description.Trim();
                assignment.StartDate = input.StartDate;
                assignment.DueDate = input.DueDate;

                await this.assignmentsRepository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Delete Assignment.
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var assignment = this.assignmentsRepository.All().FirstOrDefault(x => x.Id == id);
            if (assignment != null)
            {
                this.assignmentsRepository.Delete(assignment);
                await this.assignmentsRepository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get All Pending Assignments.
        /// </summary>">
        public IEnumerable<T> GetAllPending<T>(string sort, int page, int itemsPerPage)
        {
            var query = this.assignmentsRepository
                            .AllAsNoTracking()
                            .Where(x => x.Finished == false)
                            .AsQueryable();

            SortEmployees(ref sort, ref query);

            return query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        /// <summary>
        /// Get All Completed Assignments.
        /// </summary>
        public IEnumerable<T> GetAllCompleted<T>(string sort, int page, int itemsPerPage)
        {
            var query = this.assignmentsRepository
                            .AllAsNoTracking()
                            .Where(x => x.Finished == true)
                            .AsQueryable();

            SortEmployees(ref sort, ref query);

            return query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        /// <summary>
        /// Assign Task to Employee.
        /// </summary>
        public async Task AssignToEmployee(int employeeId, int assignmentId)
        {
            var assignment = this.assignmentsRepository
                .All()
                .FirstOrDefault(x => x.Id == assignmentId);

            var employee = this.employeesRepository
                .All()
                .FirstOrDefault(x => x.Id == employeeId);

            if (employee != null && assignment != null && assignment.Finished == false)
            {
                employee.Assignments.Add(assignment);
                await this.employeesRepository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Sort Assignments.
        /// </summary>
        private static void SortEmployees(ref string sort, ref IQueryable<Assignment> query)
        {
            if (sort == null)
            {
                sort = "startDate";
            }

            sort = sort.ToLower().Trim();

            switch (sort)
            {
                case "startdate":
                    query = query
                        .OrderBy(x => x.StartDate)
                        .ThenBy(x => x.Title);
                    break;
                case "duedate":
                    query = query
                        .OrderBy(x => x.DueDate)
                        .ThenBy(x => x.Title);
                    break;
                case "title":
                    query = query
                        .OrderBy(x => x.Title)
                        .ThenBy(x => x.Description);
                    break;
                default:
                    sort = "startdate";
                    query = query
                        .OrderBy(x => x.StartDate)
                        .ThenBy(x => x.Title);
                    break;
            }
        }
    }
}

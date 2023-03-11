namespace EMS.Services.Data
{
    using System;
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

        public AssignmentsService(
            IDeletableEntityRepository<Assignment> assignmentsRepository)
        {
            this.assignmentsRepository = assignmentsRepository;
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
                        .OrderByDescending(x => x.Title)
                        .ThenBy(x => x.DueDate);
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

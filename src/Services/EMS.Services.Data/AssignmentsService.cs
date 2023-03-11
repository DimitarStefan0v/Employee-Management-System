namespace EMS.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EMS.Data.Common.Repositories;
    using EMS.Data.Models;
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
        /// Check If Assignment with the same Title exists.
        /// </summary>
        public bool CheckIfAssignmentExist(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return false;
            }

            return this.assignmentsRepository
                .AllAsNoTracking()
                .Any(x => x.Title.ToLower() == title.ToLower().Trim());
        }
    }
}

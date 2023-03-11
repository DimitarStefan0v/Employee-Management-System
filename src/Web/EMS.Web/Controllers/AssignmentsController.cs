namespace EMS.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using EMS.Common.ErrorMessages;
    using EMS.Data.Models;
    using EMS.Services.Data;
    using EMS.Web.ViewModels.Assignments;
    using EMS.Web.ViewModels.Employees;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AssignmentsController : BaseController
    {
        private readonly IAssignmentsService assignmentsService;
        private readonly ICountsService countsService;
        private readonly UserManager<ApplicationUser> userManager;

        public AssignmentsController(
            IAssignmentsService assignmentsService,
            ICountsService countsService,
            UserManager<ApplicationUser> userManager)
        {
            this.assignmentsService = assignmentsService;
            this.countsService = countsService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateAssignmentInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAssignmentInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            if (this.assignmentsService.CheckIfAssignmentExist(inputModel.Title))
            {
                this.ModelState.AddModelError(string.Empty, AssignmentInputErrorMessages.AssignmentExists);
                return this.View(inputModel);
            }

            if (inputModel.StartDate > inputModel.DueDate)
            {
                this.ModelState.AddModelError(string.Empty, AssignmentInputErrorMessages.DueDateCanNotBeBeforeStartDate);
                return this.View(inputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.assignmentsService.CreateAsync(inputModel, user == null ? null : user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(inputModel);
            }

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All(string sortOrder = "startDate", int page = 1)
        {
            if (page <= 0)
            {
                return this.NotFound();
            }

            var itemsPerPage = 6;

            var viewModel = new AssignmentsListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = page,
                ItemsCount = this.countsService.GetAssignmentsCount(),
                ControllerName = this.ControllerContext.ActionDescriptor.ControllerName,
                ActionName = this.ControllerContext.ActionDescriptor.ActionName,
                SortOrder = sortOrder,
                Assignments = this.assignmentsService.GetAll<AssignmentInListViewModel>(sortOrder, page, itemsPerPage),
            };

            if (page > viewModel.PagesCount && viewModel.PagesCount > 0)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}

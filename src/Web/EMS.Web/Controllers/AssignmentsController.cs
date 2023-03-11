namespace EMS.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using EMS.Common.ErrorMessages;
    using EMS.Data.Models;
    using EMS.Services.Data;
    using EMS.Web.ViewModels.Assignments;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AssignmentsController : BaseController
    {
        private readonly IAssignmentsService assignmentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public AssignmentsController(
            IAssignmentsService assignmentsService, 
            UserManager<ApplicationUser> userManager)
        {
            this.assignmentsService = assignmentsService;
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

        public IActionResult All()
        {
            return this.View();
        }
    }
}

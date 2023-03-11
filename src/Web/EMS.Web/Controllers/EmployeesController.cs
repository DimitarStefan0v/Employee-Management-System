namespace EMS.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EMS.Common.ErrorMessages;
    using EMS.Data.Models;
    using EMS.Services.Data;
    using EMS.Web.ViewModels.Assignments;
    using EMS.Web.ViewModels.Employees;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class EmployeesController : BaseController
    {
        private readonly IEmployeesService employeesService;
        private readonly ICountsService countsService;
        private readonly IAssignmentsService assignmentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public EmployeesController(
            IEmployeesService employeesService,
            ICountsService countsService,
            IAssignmentsService assignmentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.employeesService = employeesService;
            this.countsService = countsService;
            this.assignmentsService = assignmentsService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateEmployeeInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (this.employeesService.CheckIfEmployeeExist(input.FirstName, input.LastName))
            {
                this.ModelState.AddModelError(string.Empty, EmployeeInputErrorMessages.DuplicateNames);
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.employeesService.CreateAsync(input, user == null ? null : user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All(string sortOrder = "ascending", int page = 1)
        {
            if (page <= 0)
            {
                return this.NotFound();
            }

            var itemsPerPage = 6;

            var viewModel = new EmployeesListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = page,
                ItemsCount = this.countsService.GetEmployeesCount(),
                ControllerName = this.ControllerContext.ActionDescriptor.ControllerName,
                ActionName = this.ControllerContext.ActionDescriptor.ActionName,
                SortOrder = sortOrder,
                Employees = this.employeesService.GetAll<EmployeeInListViewModel>(sortOrder, page, itemsPerPage),
            };

            if (page > viewModel.PagesCount && viewModel.PagesCount > 0)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var viewModel = this.employeesService.GetById<SingleEmployeeViewModel>(id);
            viewModel.Assignments = (ICollection<AssignmentsViewModel>)this.assignmentsService.GetAllPendingAssignmentsForDropDown<AssignmentsViewModel>();
            return this.View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var inputModel = this.employeesService.GetById<EditEmployeeInputModel>(id);
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEmployeeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            try
            {
                await this.employeesService.UpdateAsync(id, input);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.employeesService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult ByName(string search, string sortOrder = "ascending", int page = 1)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                this.ViewData["invalidName"] = true;
                return this.View();
            }

            if (page <= 0)
            {
                return this.NotFound();
            }

            search = search.Trim();

            var itemsPerPage = 6;

            var viewModel = new EmployeesListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = page,
                ItemsCount = this.countsService.GetEmployeesCountByName(search),
                ControllerName = this.ControllerContext.ActionDescriptor.ControllerName,
                ActionName = this.ControllerContext.ActionDescriptor.ActionName,
                SortOrder = sortOrder,
                Search = search,
                Employees = this.employeesService.GetByName<EmployeeInListViewModel>(search, sortOrder, page, itemsPerPage),
            };

            this.ViewData["name"] = search;

            return this.View(viewModel);
        }

        public async Task<IActionResult> AssignTask(int assignmentId, int employeeId)
        {
            await this.assignmentsService.AssignToEmployee(employeeId, assignmentId);
            var id = employeeId;
            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        public async Task<IActionResult> CompleteTask(int employeeId, int assignmentId)
        {
            await this.assignmentsService.CompleteAssignment(assignmentId);

            var id = employeeId;
            return this.RedirectToAction(nameof(this.ById), new { id });
        }
    }
}

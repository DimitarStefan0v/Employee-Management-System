namespace EMS.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using EMS.Data.Models;
    using EMS.Services.Data;
    using EMS.Web.ViewModels.Employees;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class EmployeesController : BaseController
    {
        private readonly IEmployeesService employeesService;
        private readonly UserManager<ApplicationUser> userManager;

        public EmployeesController(
            IEmployeesService employeesService,
            UserManager<ApplicationUser> userManager)
        {
            this.employeesService = employeesService;
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

        public IActionResult All()
        {
            var viewModel = new EmployeesListViewModel();
            viewModel.Employees = this.employeesService.GetAll<EmployeeInListViewModel>();
            return this.View(viewModel);
        }
    }
}

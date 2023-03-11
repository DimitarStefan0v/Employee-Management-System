namespace EMS.Web.Controllers
{
    using System.Diagnostics;

    using EMS.Services.Data;
    using EMS.Web.ViewModels;
    using EMS.Web.ViewModels.Employees;
    using EMS.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IEmployeesService employeesService;

        public HomeController(IEmployeesService employeesService)
        {
            this.employeesService = employeesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.BestEmployees = this.employeesService.GetBestEmployees<EmployeeInListViewModel>(5);
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

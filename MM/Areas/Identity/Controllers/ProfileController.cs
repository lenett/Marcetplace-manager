using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MM.Areas.Identity.Models;
using MM.Areas.Identity.ViewModels;
using MM.Data;
using MM.Repositories;

namespace MM.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class ProfileController : Controller
    {
        private readonly ICompanies _iCompany;

        public ProfileController(ICompanies iCompany)
        {
            _iCompany = iCompany;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ProfileViewModel profileViewModel = new ProfileViewModel();

            profileViewModel.Companies = await _iCompany.GetCurrentCompanies(HttpContext);


            return View(profileViewModel);
        }

        public IActionResult CreateCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(Companies companyModel)
        {

            Companies company = new Companies();
            company.Name = companyModel.Name;
            company.INN = companyModel.INN;
            await _iCompany.AddCompany(company, HttpContext);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditCompany(int companyModel)
        {

            return View(companyModel);
        }
    }
}

using Agent_management_MVC_frontend.Models;
using Agent_management_MVC_frontend.Services;
using Agent_management_MVC_frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Agent_management_MVC_frontend.Controllers
{
    public class GeneralController : Controller
    {
        private readonly GeneralService _generalService;
        public GeneralController(GeneralService generalService)
        {
            _generalService = generalService as GeneralService;
        }

        public async Task<IActionResult> Index()
        {
            GeneralView generalView = await _generalService.GetGeneralViewDetailsAsync();
            return View(generalView);
        }
    }
}

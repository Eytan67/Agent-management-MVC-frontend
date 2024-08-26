using Microsoft.AspNetCore.Mvc;
using Agent_management_MVC_frontend.Models;
using Newtonsoft.Json;
using Agent_management_MVC_frontend.Services;
using Agent_management_MVC_frontend.ViewModels;
using Agent_management_MVC_frontend.Interfaces;

namespace Agent_management_MVC_frontend.Controllers
{
    public class MissionsController : Controller
    {
        private readonly MissionsService _missionsService;
        public MissionsController(MissionsService missionsService)
        {
            _missionsService = missionsService as MissionsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetProposalMissions()
        {
            try
            {
                List<MissionManagement> res = await _missionsService.GetMissionsAndDetailsAsync();

                return View(res);
            }
            catch (Exception ex)
            {
                return new ContentResult { Content = ex.Message };
            }

        }

        public async Task<IActionResult> Commit(int missionId)
        {
            await _missionsService.UpdateMissionStatus(missionId);

            return RedirectToAction("GetProposalMissions");
        }
        public async Task<IActionResult> Details(int missionId)
        {
            var mission = await _missionsService.GetMissionByIdAsync(missionId);
            return View(mission);
        }
    }
}

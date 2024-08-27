using Agent_management_MVC_frontend.Services;
using Microsoft.AspNetCore.Mvc;



namespace Agent_management_MVC_frontend.Controllers
{
    public class AgentsController : Controller
    {

        private readonly AgentService _agentsService;
        private readonly MissionsService _missionsService;

        public AgentsController(AgentService agentsService, MissionsService missionsService)
        {
            _agentsService = agentsService ;
            _missionsService = missionsService;
        }
     
        
        public async Task<IActionResult> Index()
        {
            var agents = await _agentsService.GetAgentsDetailseAsync();

            return View(agents);
        }
        
        public async Task<IActionResult> Details(int missionId)
        {
            var mision = await _missionsService.GetMissionByIdAsync(missionId);
        
            return View(mision);
        }
    }
}

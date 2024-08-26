using Agent_management_MVC_frontend.Enum;
using Agent_management_MVC_frontend.Enums;
using Agent_management_MVC_frontend.Interfaces;
using Agent_management_MVC_frontend.Models;
using Agent_management_MVC_frontend.ViewModels;
using System.Net.Http.Json;

namespace Agent_management_MVC_frontend.Services
{
    public class GeneralService 
    {
        private string _GetAllAgentsUrl = "http://localhost:5286/Agents";
        private string _GetAllTargetsUrl = "http://localhost:5286/Targets";
        private string _GetAllMissionsUrl = "http://localhost:5286/Missions";




        private readonly HttpClient _httpClient;
        public GeneralService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Agent>> GetAgentsAsync()
        {
            var agents = await _httpClient.GetFromJsonAsync<List<Agent>>(_GetAllAgentsUrl);
            return agents;
        }

        public async Task<List<Target>> GetTargetsAsync()
        {
            var targets = await _httpClient.GetFromJsonAsync<List<Target>>(_GetAllTargetsUrl);
            return targets;
        }

        public async Task<List<Mission>> GetMissionsAsync()
        {
            var mission = await _httpClient.GetFromJsonAsync<List<Mission>>(_GetAllMissionsUrl);
            return mission;
        }

        public async Task<GeneralView> GetGeneralViewDetailsAsync()
        {
            var agents = await GetAgentsAsync();
            var activeAgents = agents.Where(a => a.Status == EAgentStatus.Active).ToList();

            var targets = await GetTargetsAsync();
            var eliminatedTargets = targets.Where(t => t.Status == ETargetStatus.Eeliminated).ToList();

            var missions = await GetMissionsAsync();
            var inProgresMissions = missions.Where(m => m.Status == EMissionsStatus.CommandForMission).ToList();
            
            var ProposalAgents = missions.Select(m => m.AgentId).ToList();
            var set = new HashSet<int>(ProposalAgents);

            GeneralView generalView = new GeneralView(agents.Count()
                , activeAgents.Count()
                , targets.Count()
                , eliminatedTargets.Count()
                , missions.Count()
                , inProgresMissions.Count()
                , $"{targets.Count()} / {set.Count()}"
                );

            return generalView;
        }
    }
}

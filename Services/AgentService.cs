using Agent_management_MVC_frontend.Enum;
using Agent_management_MVC_frontend.Enums;
using Agent_management_MVC_frontend.Models;
using Agent_management_MVC_frontend.ViewModels;
using System.Net.Http.Json;

namespace Agent_management_MVC_frontend.Services
{
    public class AgentService
    {
        private string _GetAllAgentsUrl = "http://localhost:5286/Agents";
        private string _GetAgentMissionUrl = "http://localhost:5286/Missions/";

        private readonly HttpClient _httpClient;
        public AgentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Agent>> GetAgentsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Agent>>(_GetAllAgentsUrl);

            return response.ToList();
        }

        public async Task<List<AgentDetailse>> GetAgentsDetailseAsync()
        {
            var agents = await GetAgentsAsync();

            List<AgentDetailse> result = new List<AgentDetailse>();
            foreach (var agent in agents)
            {
                var agentMission = agent.Status == EAgentStatus.Active ? await FindAgentMission(agent.Id) : null;
                AgentDetailse agentDetailse = new AgentDetailse()
                {
                    Name = agent.Nickname,
                    Location = $"({agent.Location.X}, {agent.Location.Y})",
                    Status = agent.Status == EAgentStatus.Dormant ? "Dormant" : "Active",
                    Mission = agentMission,
                    Stars = agent.Stars
                };
                result.Add(agentDetailse);
            }
            return result;
        }
        private async Task<Mission> FindAgentMission(int id)
        {
            var mission = await _httpClient.GetFromJsonAsync<Mission>(_GetAgentMissionUrl + id);
            return mission;
        }
    }
}

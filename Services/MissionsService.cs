using Agent_management_MVC_frontend.Models;
using Agent_management_MVC_frontend.Enum;
using Agent_management_MVC_frontend.ViewModels;


namespace Agent_management_MVC_frontend.Services
{
    public class MissionsService 
    {
        private string _GetAllMissionsUrl = "http://localhost:5286/Missions";
        private string _GetMissionUrl = "http://localhost:5286/Missions/";
        private string _PutMissionStatusUrl = "http://localhost:5286/Missions/";

        private string _GetAgentUrl = "http://localhost:5286/Agents/";

        private string _GetTargetUrl = "http://localhost:5286/Targets/";


        private readonly HttpClient _httpClient;
        public MissionsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Mission>> GetProposalMissionsAsync()
        {

            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Mission>>(_GetAllMissionsUrl);
            var proposalMissions = response.Where(m => m.Status == EMissionsStatus.proposal).ToList();

            return proposalMissions;
        }
        public async Task<Mission> GetMissionByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Mission>(_GetMissionUrl + id);
            return response;
        }
        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Agent>(_GetAgentUrl + id);
            return response;
        }

        public async Task<Target> GetTargetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Target>(_GetTargetUrl + id);
            return response;
        }

        public async Task<List<MissionManagement>> GetMissionsAndDetailsAsync()
        {
            List<MissionManagement> missionManagements = new List<MissionManagement>();
            var proposalMissions = await GetProposalMissionsAsync();

            foreach (var mission in proposalMissions)
            {
                Agent agent = await GetAgentByIdAsync(mission.AgentId);
                Target target = await GetTargetByIdAsync(mission.TargetId);
                var missionManagement = new MissionManagement(mission.Id, agent, target);
                missionManagements.Add(missionManagement);
            }
            return missionManagements;
        }
        public async Task UpdateMissionStatus(int missionId)
        {
            var contentBody = new { Token = "Updated", status = "assigned" };
            var content = JsonContent.Create(contentBody);
            await _httpClient.PutAsync(_PutMissionStatusUrl + missionId, content);
           
            return;
        }

    }
}

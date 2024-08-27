using Agent_management_MVC_frontend.Models;
using Agent_management_MVC_frontend.Shared;
using System.Reflection;

namespace Agent_management_MVC_frontend.ViewModels
{
    public class MissionManagement
    {
        public int MissionId { get; set; }
        public string AgentName {  get; set; }
        public Coordinates AgentLocation { get; set; }
        public string TargetName { get; set; }
        public Coordinates TargetLocation { get; set; }
        public string TargetDescription {  get; set; }
        public double Distance { get; set; }
        public TimeSpan EliminationTime { get { return CalculateLeftTime(Distance); } }

        public MissionManagement(int missionId, Agent agent, Target target)
        {
            this.MissionId = missionId;
            AgentName = agent.Nickname;
            AgentLocation = agent.Location;
            TargetName = target.Name;
            TargetLocation = target.Location;
            TargetDescription = target.Position;
            this.Distance = Shared.Distance.GetDistance(agent.Location, target.Location);
        }

        private TimeSpan CalculateLeftTime(double distance)
        {
            double seconds = (distance / 5) * 3600;
            TimeSpan leftTime = TimeSpan.FromSeconds(seconds);
            return leftTime;
        }

    }
}

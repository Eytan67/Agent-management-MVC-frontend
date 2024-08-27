using Agent_management_MVC_frontend.Enum;

namespace Agent_management_MVC_frontend.ViewModels
{
    public class MissionView
    {
        public string Status {  get; set; }
        public string AgentNane { get; set; }
        public string TargetName { get; set; }

        public string StartTime { get; set; }
        public string leftTime { get; set; }
    }
}

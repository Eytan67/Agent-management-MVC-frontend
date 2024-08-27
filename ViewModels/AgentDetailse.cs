using Agent_management_MVC_frontend.Models;

namespace Agent_management_MVC_frontend.ViewModels
{
    public class AgentDetailse
    {
        public  string Name {  get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public Mission? Mission { get; set; }
        public string? LeftTime { get 
            { 
                return Mission != null ? Mission.leftTime.ToString() : null; 
            } }
        public int Stars { get; set; }
    }
}

using Agent_management_MVC_frontend.Enums;
using System.ComponentModel.DataAnnotations;
namespace Agent_management_MVC_frontend.Models
{
    public class Agent 
    {
        [Key]
        public int Id {  get; set; }
        public string photoUrl { get; set; }
        public string Nickname { get; set; }
        public Coordinates? Location { get; set; }
        public EAgentStatus Status { get; set; }
        public int Stars {  get; set; }
    }
}

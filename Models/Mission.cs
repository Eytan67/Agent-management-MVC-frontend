using System.ComponentModel.DataAnnotations;
using Agent_management_MVC_frontend.Enum;

namespace Agent_management_MVC_frontend.Models
{
    public class Mission
    {
        [Key]
        public int Id { get; set; }
        public EMissionsStatus Status { get; set; }
        public int AgentId { get; set; }
        public int TargetId { get; set; }

    }
}

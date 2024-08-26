using Agent_management_MVC_frontend.Enums;
using System.ComponentModel.DataAnnotations;

namespace Agent_management_MVC_frontend.Models
{
    public class Target
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Coordinates? Location { get; set; }
        public string Position {  get; set; }
        public string photoUrl {  get; set; }
        public ETargetStatus Status {  get; set; }
    }
}

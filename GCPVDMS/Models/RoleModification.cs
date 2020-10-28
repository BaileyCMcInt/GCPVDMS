using System.ComponentModel.DataAnnotations;

namespace GCPVDMS.Models
{
    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[] AddIds { get; set; }

        public string[] DeleteIds { get; set; }
    }
}
//The RoleModification class code will help in doing the changes to a role.
using System.ComponentModel.DataAnnotations;

namespace GeoObservables.Api.Request
{
    public class RolesRolRequest
    {
        [Required]
        public string Role { get; set; }

    }
}

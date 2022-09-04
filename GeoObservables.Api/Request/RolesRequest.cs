using System.ComponentModel.DataAnnotations;

namespace GeoObservables.Api.Request
{
    public class RolesRequest
    {
        [Required]
        public int Id { get; set; }

    }
}

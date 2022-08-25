using System.ComponentModel.DataAnnotations;

namespace GeoObservables.Api.ViewModels
{
    public class RolesViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Role { get; set; }
    }
}

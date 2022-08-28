using System.ComponentModel.DataAnnotations;

namespace GeoObservables.Api.ViewModels
{
    public class LoginViewModel
    {
        public string User { get; set; }

        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Rol { get; set; }
        [Required]
        public int idRol { get; set; }
    }
}

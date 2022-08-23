using System.ComponentModel.DataAnnotations;

namespace GeoObservables.Api.ViewModels
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int IdRole { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}

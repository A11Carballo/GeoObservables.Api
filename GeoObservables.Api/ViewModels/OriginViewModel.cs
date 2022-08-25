using System.ComponentModel.DataAnnotations;

namespace GeoObservables.Api.ViewModels
{
    public class OriginViewModel
    {
        public int Id { get; set; }
        [Required]
        public String OriginInfo { get; set; }
        [Required]
        public String Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace GeoObservables.Api.ViewModels
{
    public class HFlowdataViewModel
    {
        public int Id { get; set; }
        [Required]
        public double Long { get; set; }
        [Required]
        public double Lat { get; set; }
        [Required]
        public double Height { get; set; }        
        [Required]
        public double Hflow { get; set; }
        public int idOrigin { get; set; }
        public string Description { get; set; }
        public int Datacreated { get; set; }
        public int Datamodified { get; set; }
        public int idUserCreate { get; set; }
    }
}

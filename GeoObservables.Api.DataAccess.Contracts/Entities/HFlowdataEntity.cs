using System;
using System.Collections.Generic;
using System.Linq;
namespace GeoObservables.Api.DataAccess.Contracts.Entities
{
    public class HFlowdataEntity
    {
        public int Id { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public double Height { get; set; }
        public double Hflow { get; set; }
        public int idOrigin { get; set; }
        public string Description { get; set; }
        public DateTime Datacreated { get; set; }
        public DateTime Datamodified { get; set; }
        public int idUserCreate { get; set; }
        public virtual OriginEntity Origin { get; set; }
        public virtual UsersEntity User { get; set; }

    }
}

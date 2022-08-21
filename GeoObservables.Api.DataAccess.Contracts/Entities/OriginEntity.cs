using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.DataAccess.Contracts.Entities
{
    public class OriginEntity
    {
        public int Id { get; set; }
        public String OriginInfo { get; set; }
        public String Description { get; set; }
    }
}

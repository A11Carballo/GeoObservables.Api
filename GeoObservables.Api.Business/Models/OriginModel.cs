using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.Business.Models
{
    public class OriginModel
    {
        public int Id { get; set; }
        public String OriginInfo { get; set; }
        public String Description { get; set; }
        public virtual ICollection<HFlowdataModel> HFlowdata { get; set; }
    }
}

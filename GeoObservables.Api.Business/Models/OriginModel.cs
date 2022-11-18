using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.Business.Models
{
    public class OriginModel
    {
        #region Constructor & Destructor
        /// <summary>
        /// Initializes a new instance of OriginModel class.
        /// </summary>
        public OriginModel()
        {
        }

        public OriginModel(String originInfo, String description = "No description")
        {
            this.OriginInfo = originInfo;
            this.Description = description;
        }
        #endregion

        public int Id { get; set; }
        public String OriginInfo { get; set; }
        public String Description { get; set; }
        public virtual ICollection<HFlowdataModel> HFlowdata { get; set; }
    }
}

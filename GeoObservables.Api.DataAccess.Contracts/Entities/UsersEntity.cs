using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.DataAccess.Contracts.Entities
{
    public class UsersEntity
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int IdRole { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual RolesEntity Roles { get; set; }
        public virtual ICollection<HFlowdataEntity> HFlowdata { get; set; }
    }
}

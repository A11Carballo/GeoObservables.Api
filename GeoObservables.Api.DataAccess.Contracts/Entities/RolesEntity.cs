using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.DataAccess.Contracts.Entities
{
    public class RolesEntity
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public virtual ICollection<UsersEntity> Users { get; set; }
    }
}

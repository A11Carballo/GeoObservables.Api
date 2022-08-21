using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.Business.Models
{
    public class RolesModel
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public virtual ICollection<UsersModel> Users { get; set; }
    }
}

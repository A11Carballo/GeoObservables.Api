using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.Business.Models { 
    public class UsersModel
    {
        public UsersModel()
        {
        }
        public UsersModel(string user, string password, string mail, int idRole, string description="No description", bool active=false)
        {
            this.User = user;
            this.Password = password;
            this.Mail = mail;
            this.IdRole = idRole;
            this.Description = description; 
            this.DateCreated = DateTime.Today;
            this.Active = active;
        }
        public int Id { get; set; }
        public string User { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int IdRole { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual RolesModel Roles { get; set; }
        public virtual ICollection<HFlowdataModel> HFlowdata { get; set; }
    }
}

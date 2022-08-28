using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.Business.Models
{
    public class LoginModel
    {
        //Lógica de negocio de la entidad Login
        // Tendremos las propiedadas de nuestra entidad.
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}

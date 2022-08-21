using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.Aplication.Contracts.Services
{
    public interface IRolesServices
    {
        Task<string> GetRol(int idRol);
    }
}

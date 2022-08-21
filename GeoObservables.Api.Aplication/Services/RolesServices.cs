using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.DataAccess.Contracts.Repositories;

namespace GeoObservables.Api.Aplication.Services
{
    public class RolesServices : IRolesServices
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesServices(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public async Task<string> GetRol(int idRol)
        {
            var role = await _rolesRepository.Get(idRol);

            return role.Role;
        }
    }
}

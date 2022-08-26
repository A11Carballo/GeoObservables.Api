using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;

namespace GeoObservables.Api.Aplication.Services
{
    public class RolesServices : Lazy<IRolesServices>
    {
        private readonly Lazy<IRolesRepository> _rolesRepository;
        public RolesServices(Lazy<IRolesRepository> rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public async Task<RolesModel> AddRol(RolesModel rol)
        {
            var addRol = await _rolesRepository.Value.Add(RolesMapper.Map(rol));

            return RolesMapper.Map(addRol);
        }

        public async Task<bool> DeleteRol(int idRol)
        {
            var isDelete = await _rolesRepository.Value.DeleteAsyncBool(idRol);

            return isDelete;
        }

        public async Task<IEnumerable<RolesModel>> GetAllRoles()
        {
            var allRoles = await _rolesRepository.Value.GetAll();

            return allRoles.Select(RolesMapper.Map);
        }

        public async Task<RolesModel> GetRol(int idRol)
        {
            var role = await _rolesRepository.Value.Get(idRol);

            return RolesMapper.Map(role);
        }

        public async Task<RolesModel> UpdateRol(RolesModel rol)
        {
            var updRol = await _rolesRepository.Value.Update(RolesMapper.Map(rol));

            return (RolesMapper.Map(updRol));
        }

    }
}

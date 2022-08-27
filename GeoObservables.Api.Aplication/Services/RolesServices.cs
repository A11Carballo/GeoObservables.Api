using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;

namespace GeoObservables.Api.Aplication.Services
{
    public class RolesServices : IRolesServices
    {
        private readonly IAppConfig _appConfig;
        private readonly int _maxTrys;
        private readonly TimeSpan _timeToWait;
        private readonly IRolesRepository _rolesRepository;
        public RolesServices(IRolesRepository rolesRepository, IAppConfig appConfig)
        {
            _rolesRepository = rolesRepository;
            _appConfig = appConfig;

            _maxTrys = _appConfig.MaxTrys();
            _timeToWait = TimeSpan.FromSeconds(_appConfig.SecondsToWait());
        }

        public async Task<RolesModel> AddRol(RolesModel rol)
        {
            var addRol = await _rolesRepository.Add(RolesMapper.Map(rol));

            return RolesMapper.Map(addRol);
        }

        public async Task<bool> DeleteRol(int idRol)
        {
            var isDelete = await _rolesRepository.DeleteAsyncBool(idRol);

            return isDelete;
        }

        public async Task<IEnumerable<RolesModel>> GetAllRoles()
        {
            var allRoles = await _rolesRepository.GetAll();

            return allRoles.Select(RolesMapper.Map);
        }

        public async Task<RolesModel> GetRol(int idRol)
        {
            var role = await _rolesRepository.Get(idRol);

            return RolesMapper.Map(role);
        }

        public async Task<RolesModel> UpdateRol(RolesModel rol)
        {
            var updRol = await _rolesRepository.Update(RolesMapper.Map(rol));

            return (RolesMapper.Map(updRol));
        }

    }
}

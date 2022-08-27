using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;
using Polly;

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
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return RolesMapper.Map(await _rolesRepository.Add(RolesMapper.Map(rol)));
            });
        }

        public async Task<bool> DeleteRol(int idRol)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return await _rolesRepository.DeleteAsyncBool(idRol);
            });
        }

        public async Task<IEnumerable<RolesModel>> GetAllRoles()
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return (await _rolesRepository.GetAll()).Select(RolesMapper.Map);
            });
        }

        public async Task<RolesModel> GetRol(int idRol)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return RolesMapper.Map(await _rolesRepository.Get(idRol));
            });
        }

        public async Task<RolesModel> UpdateRol(RolesModel rol)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return (RolesMapper.Map(await _rolesRepository.Update(RolesMapper.Map(rol))));
            });
        }

    }
}

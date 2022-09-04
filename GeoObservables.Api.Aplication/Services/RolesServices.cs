﻿using GeoObservables.Api.Aplication.Contracts.Configuration;
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

        public async Task<bool> DeleteRol(RolesModel rol)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return await _rolesRepository.DeleteAsyncBool(rol.Id);
            });
        }

        public async Task<bool> DeleteRolRequest(int idRolRequest)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return await _rolesRepository.DeleteAsyncBool(idRolRequest);
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

        public async Task<RolesModel> GetRol(RolesModel rol)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return RolesMapper.Map(await _rolesRepository.Get(rol.Id));
            });
        }

        public async Task<RolesModel> GetRolRequest(int idRolRequest)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return RolesMapper.Map(await _rolesRepository.Get(idRolRequest));
            });
        }

        public async Task<RolesModel> GetRolByRol(string roll)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return RolesMapper.Map(await _rolesRepository.GetByRol(roll));
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

        public async Task<bool> ExistRol(int idRol)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return await _rolesRepository.Exist(idRol);
            });
        }

    }
}

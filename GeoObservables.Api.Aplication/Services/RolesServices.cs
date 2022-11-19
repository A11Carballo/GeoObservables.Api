﻿using System.Linq.Expressions;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;
using Microsoft.Extensions.Logging;
using Polly;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace GeoObservables.Api.Aplication.Services
{
    public class RolesServices : IRolesServices
    {
        private readonly IAppConfig _appConfig;
        private readonly int _maxTrys;
        private readonly TimeSpan _timeToWait;
        private readonly IRolesRepository _rolesRepository;
        private readonly ILogger<RolesServices> _logger;
        public RolesServices(IRolesRepository rolesRepository, IAppConfig appConfig, ILogger<RolesServices> logger)
        {
            this._rolesRepository = rolesRepository;

            this._appConfig = appConfig;

            this._maxTrys = _appConfig.MaxTrys();

            this._timeToWait = TimeSpan.FromSeconds(_appConfig.SecondsToWait());

            this._logger = logger;
        }

        public async Task<RolesModel> AddRol(RolesModel rol)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"AddRol {rol} Rol");

                return RolesMapper.Map(await _rolesRepository.Add(RolesMapper.Map(rol)));
            });
        }

        public async Task<bool> DeleteRol(RolesModel rol)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"Getting {rol.Id} Rol");

                return await _rolesRepository.DeleteAsyncBool(rol.Id);
            });
        }

        public async Task<bool> DeleteRolRequest(int idRolRequest)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"Getting {idRolRequest} Rol");

                return await _rolesRepository.DeleteAsyncBool(idRolRequest);
            });
        }

        public async Task<IEnumerable<RolesModel>> GetAllRoles()
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"GetAllRoles");

                return (await _rolesRepository.GetAll()).Select(RolesMapper.Map);
            });
        }

        public async Task<RolesModel> GetRol(int idRol, string rol)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"Getting {idRol} Rol");

                return RolesMapper.Map(await _rolesRepository.Get(idRol));
            });
        }

        public async Task<RolesModel> GetRolRequest(int idRolRequest)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"Getting {idRolRequest} Rol");

                return RolesMapper.Map(await _rolesRepository.Get(idRolRequest));
            });
        }

        public async Task<RolesModel> GetRolByRol(string roll)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"GetRolByRol {roll} Rol");

                return RolesMapper.Map(await _rolesRepository.GetByRol(roll));
            });
        }

        public async Task<RolesModel> UpdateRol(RolesModel rol)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"UpdateRol {rol} Rol");

                return (RolesMapper.Map(await _rolesRepository.Update(RolesMapper.Map(rol))));
            });
        }

        public async Task<bool> ExistRol(int idRol)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"ExistRol {idRol} idRol");

                return await _rolesRepository.Exist(idRol);
            });
        }

        public async Task<RolesModel> GetByFilterRol(Expression<Func<RolesEntity, bool>> filter = null)
        {

            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"GetByFilterRol {filter} filter");

                var RolesFilter = await _rolesRepository.GetByFilter(filter);

                return RolesMapper.Map(RolesFilter.First());
            });

        }

    }
}

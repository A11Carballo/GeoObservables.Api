using System.Linq.Expressions;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Exceptions;
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
           _rolesRepository = rolesRepository;

           _appConfig = appConfig;

           _maxTrys = _appConfig.MaxTrys();

           _timeToWait = TimeSpan.FromSeconds(_appConfig.SecondsToWait());

           _logger = logger;
        }

        public async Task<RolesModel> AddRol(RolesModel rol)
        {
            try
            {
                var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

                return await retryPolity.ExecuteAsync(async () =>
                {
                    _logger.LogInformation($"AddRol {rol} Rol");

                    return RolesMapper.Map(await this._rolesRepository.Add(RolesMapper.Map(rol)));
                });
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex);
            }
        }

        public async Task<bool> DeleteRol(RolesModel rol)
        {
            try
            {
                var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

                return await retryPolity.ExecuteAsync(async () =>
                {
                    _logger.LogInformation($"Getting {rol.Id} Rol");

                    return await this._rolesRepository.DeleteAsyncBool(rol.Id);
                });
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex);
            }
        }

        public async Task<bool> DeleteRolRequest(int idRolRequest)
        {
            try
            {
                var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

                return await retryPolity.ExecuteAsync(async () =>
                {
                    _logger.LogInformation($"Getting {idRolRequest} Rol");

                    return await this._rolesRepository.DeleteAsyncBool(idRolRequest);
                });
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex);
            }
        }

        public async Task<IEnumerable<RolesModel>> GetAllRoles()
        {
            try
            {
                var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

                return await retryPolity.ExecuteAsync(async () =>
                {
                    _logger.LogInformation($"GetAllRoles");

                    return (await this._rolesRepository.GetAll()).Select(RolesMapper.Map);
                });
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex);
            }
        }

        public async Task<RolesModel> GetRol(int idRol)
        {
            try
            {
                var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

                return await retryPolity.ExecuteAsync(async () =>
                {
                    _logger.LogInformation($"Getting {idRol} Rol");

                    return RolesMapper.Map(await this._rolesRepository.Get(idRol));
                });
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex);
            }
        }

        public async Task<RolesModel> GetRolRequest(int idRolRequest)
        {
            try
            {
                var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

                return await retryPolity.ExecuteAsync(async () =>
                {
                    _logger.LogInformation($"Getting {idRolRequest} Rol");

                    return RolesMapper.Map(await this._rolesRepository.Get(idRolRequest));
                });
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex);
            }
        }

        public async Task<RolesModel> GetRolByRol(string roll)
        {
            try
            {
                var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

                return await retryPolity.ExecuteAsync(async () =>
                {
                    ._logger.LogInformation($"GetRolByRol {roll} Rol");

                    return RolesMapper.Map(await this._rolesRepository.GetByRol(roll));
                });
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex);
            }
        }

        public async Task<RolesModel> UpdateRol(RolesModel rol)
        {
            try
            {
                var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

                return await retryPolity.ExecuteAsync(async () =>
                {
                    _logger.LogInformation($"UpdateRol {rol} Rol");

                    return (RolesMapper.Map(await this._rolesRepository.Update(RolesMapper.Map(rol))));
                });
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex);
            }
        }

        public async Task<bool> ExistRol(int idRol)
        {
            try
            {
                var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

                return await retryPolity.ExecuteAsync(async () =>
                {
                    _logger.LogInformation($"ExistRol {idRol} idRol");

                    return await this._rolesRepository.Exist(idRol);
                });
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex);
            }
        }

        public async Task<RolesModel> GetByFilterRol(Expression<Func<RolesEntity, bool>> filter = null)
        {
            try
            {
                var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

                return await retryPolity.ExecuteAsync(async () =>
                {
                    _logger.LogInformation($"GetByFilterRol {filter} filter");

                    var RolesFilter = await this._rolesRepository.GetByFilter(filter);

                    return RolesMapper.Map(RolesFilter.First());
                });
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex);
            }

        }

    }
}

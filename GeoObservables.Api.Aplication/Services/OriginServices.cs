using System.Linq.Expressions;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;
using GeoObservables.Api.DataAccess.Repositories;
using Microsoft.Extensions.Logging;
using Polly;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace GeoObservables.Api.Aplication.Services
{
    public class OriginServices : IOriginServices
    {
        private readonly IOriginRepository _originRepository;
        private readonly IAppConfig _appConfig;
        private readonly int _maxTrys;
        private readonly TimeSpan _timeToWait;
        private readonly ILogger<OriginServices> _logger;

        public OriginServices(IOriginRepository originRepository, IAppConfig appConfig, ILogger<OriginServices> logger)
        {
            this._originRepository = originRepository;

            this._appConfig = appConfig;

            this._maxTrys = _appConfig.MaxTrys();

            this._timeToWait = TimeSpan.FromSeconds(_appConfig.SecondsToWait());

            this._logger = logger;
        }

        public async Task<OriginModel> AddOrigin(OriginModel origin)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"AddOrigin {origin} origin");

                return OriginMapper.Map(await _originRepository.Add(OriginMapper.Map(origin)));
            });
        }

        public async Task<bool> DeleteOrigin(int idOrigin)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"DeleteOrigin {idOrigin} idOrigin");

                return await _originRepository.DeleteAsyncBool(idOrigin);
            });
        }

        public async Task<IEnumerable<OriginModel>> GetAllOrigins()
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"GetAllOrigins");
                return (await _originRepository.GetAll()).Select(OriginMapper.Map);
            });
        }

        public async Task<OriginModel> GetOrigin(int idOrigin)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"GetOrigin {idOrigin} idOrigin");

                return OriginMapper.Map(await _originRepository.Get(idOrigin));
            });
        }

        public async Task<OriginModel> UpdateOrigin(OriginModel origin)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"UpdateOrigin {origin} origin");

                return (OriginMapper.Map(await _originRepository.Update(OriginMapper.Map(origin))));
            });
        }

        public async Task<bool> ExistOrigin(int idRol)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"ExistOrigin {idRol} idRol");

                return await _originRepository.Exist(idRol);
            });
        }

        public async Task<OriginModel> GetByFilterOrigin(Expression<Func<OriginEntity, bool>> filter = null)
        {

            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"GetByFilterOrigin {filter} filter");

                var OoriginFilter = await _originRepository.GetByFilter(filter);

                return OriginMapper.Map(OoriginFilter.First());
            });

        }
    }
}

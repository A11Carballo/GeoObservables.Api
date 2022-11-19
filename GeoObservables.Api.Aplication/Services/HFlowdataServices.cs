using System.Linq.Expressions;
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
    public class HFlowdataServices : IHFlowdataServices
    {
        private readonly IHFlowdataRepository _hFlowdataServices;
        private readonly IAppConfig _appConfig;
        private readonly int _maxTrys;
        private readonly TimeSpan _timeToWait;
        private readonly ILogger<HFlowdataServices> _logger;

        public HFlowdataServices(IHFlowdataRepository hFlowdataServices, IAppConfig appConfig, ILogger<HFlowdataServices> logger)
        {
            this._hFlowdataServices = hFlowdataServices;

            this._appConfig = appConfig;

            this._maxTrys = _appConfig.MaxTrys();

            this._timeToWait = TimeSpan.FromSeconds(_appConfig.SecondsToWait());

            this._logger = logger;
        }

        public async Task<HFlowdataModel> AddHFlowdata(HFlowdataModel HFlowdata)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"AddHFlowdata {HFlowdata} HFlowdata");

                return HFlowdataMapper.Map(await _hFlowdataServices.Add(HFlowdataMapper.Map(HFlowdata)));
            });
        }

        public async Task<bool> DeleteHFlowdata(int idHData)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"DeleteHFlowdata {idHData} idHData");

                return await _hFlowdataServices.DeleteAsyncBool(idHData);
            });
        }

        public async Task<IEnumerable<HFlowdataModel>> GetAllHFlows()
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"GetAllHFlows");

                return (await _hFlowdataServices.GetAll()).Select(HFlowdataMapper.Map);
            });
        }

        public async Task<HFlowdataModel> GetHFlowdata(int idHData)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"GetHFlowdata {idHData} idHData");

                return HFlowdataMapper.Map(await _hFlowdataServices.Get(idHData));
            });
        }

        public async Task<HFlowdataModel> UpdateHFlowdata(HFlowdataModel HFlowdata)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"UpdateHFlowdata {HFlowdata} HFlowdata");

                return (HFlowdataMapper.Map(await _hFlowdataServices.Update(HFlowdataMapper.Map(HFlowdata))));
            });
        }

        public async Task<HFlowdataModel> GetByFilterOrigin(Expression<Func<HFlowdataEntity, bool>> filter = null)
        {

            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"GetByFilterOrigin {filter} filter");

                var HFlowdataFilter = await _hFlowdataServices.GetByFilter(filter);

                return HFlowdataMapper.Map(HFlowdataFilter.First());
            });

        }
    }
}

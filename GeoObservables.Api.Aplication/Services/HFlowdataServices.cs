using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;
using Polly;

namespace GeoObservables.Api.Aplication.Services
{
    public class HFlowdataServices : IHFlowdataServices
    {
        private readonly IHFlowdataRepository _hFlowdataServices;
        private readonly IAppConfig _appConfig;
        private readonly int _maxTrys;
        private readonly TimeSpan _timeToWait;

        public HFlowdataServices(IHFlowdataRepository hFlowdataServices, IAppConfig appConfig)
        {
            _hFlowdataServices = hFlowdataServices;
            _appConfig = appConfig;

            _maxTrys = _appConfig.MaxTrys();
            _timeToWait = TimeSpan.FromSeconds(_appConfig.SecondsToWait());
        }

        public async Task<HFlowdataModel> AddHFlowdata(HFlowdataModel HFlowdata)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return HFlowdataMapper.Map(await _hFlowdataServices.Add(HFlowdataMapper.Map(HFlowdata)));
            });
        }

        public async Task<bool> DeleteHFlowdata(int idHData)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return await _hFlowdataServices.DeleteAsyncBool(idHData);
            });
        }

        public async Task<IEnumerable<HFlowdataModel>> GetAllHFlows()
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return (await _hFlowdataServices.GetAll()).Select(HFlowdataMapper.Map);
            });
        }

        public async Task<HFlowdataModel> GetHFlowdata(int idHData)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return HFlowdataMapper.Map(await _hFlowdataServices.Get(idHData));
            });
        }

        public async Task<HFlowdataModel> UpdateHFlowdata(HFlowdataModel HFlowdata)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return (HFlowdataMapper.Map(await _hFlowdataServices.Update(HFlowdataMapper.Map(HFlowdata))));
            });
        }
    }
}

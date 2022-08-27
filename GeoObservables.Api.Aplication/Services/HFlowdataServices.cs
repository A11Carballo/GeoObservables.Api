using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;

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
            var addHFlow = await _hFlowdataServices.Add(HFlowdataMapper.Map(HFlowdata));

            return HFlowdataMapper.Map(addHFlow);
        }

        public async Task<bool> DeleteHFlowdata(int idHData)
        {
            var isDelete = await _hFlowdataServices.DeleteAsyncBool(idHData);

            return isDelete;
        }

        public async Task<IEnumerable<HFlowdataModel>> GetAllHFlows()
        {
            var allHFlows = await _hFlowdataServices.GetAll();

            return allHFlows.Select(HFlowdataMapper.Map);
        }

        public async Task<HFlowdataModel> GetHFlowdata(int idHData)
        {
            var hFlowdata = await _hFlowdataServices.Get(idHData);

            return HFlowdataMapper.Map(hFlowdata);
        }

        public async Task<HFlowdataModel> UpdateHFlowdata(HFlowdataModel HFlowdata)
        {
            var updHFlow = await _hFlowdataServices.Update(HFlowdataMapper.Map(HFlowdata));

            return (HFlowdataMapper.Map(updHFlow));
        }
    }
}

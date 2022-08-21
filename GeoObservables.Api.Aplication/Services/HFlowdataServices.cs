using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.DataAccess.Contracts.Repositories;

namespace GeoObservables.Api.Aplication.Services
{
    public class HFlowdataServices : IHFlowdataServices
    {
        private readonly IHFlowdataRepository _hFlowdataServices;
        public HFlowdataServices(IHFlowdataRepository hFlowdataServices)
        {
            _hFlowdataServices = hFlowdataServices;
        }

        public async Task<double> GetHFlowdata(int idHData)
        {
            var hFlowdata = await _hFlowdataServices.Get(idHData);

            return hFlowdata.Hflow;
        }
    }
}

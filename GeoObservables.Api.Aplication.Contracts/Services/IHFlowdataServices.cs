using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Business.Models;

namespace GeoObservables.Api.Aplication.Contracts.Services
{
    public interface IHFlowdataServices
    {
        Task<HFlowdataModel> GetHFlowdata(int idHData);
        Task<HFlowdataModel> AddHFlowdata(HFlowdataModel HFlowdata);
        Task<IEnumerable<HFlowdataModel>> GetAllHFlows();
        Task<bool> DeleteHFlowdata(int idHData);
        Task<HFlowdataModel> UpdateHFlowdata(HFlowdataModel HFlowdata);
    }
}

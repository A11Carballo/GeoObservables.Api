using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Entities;

namespace GeoObservables.Api.Aplication.Contracts.Services
{
    public interface IHFlowdataServices
    {
        Task<HFlowdataModel> GetHFlowdata(int idHData);
        Task<HFlowdataModel> AddHFlowdata(HFlowdataModel HFlowdata);
        Task<IEnumerable<HFlowdataModel>> GetAllHFlows();
        Task<bool> DeleteHFlowdata(int idHData);
        Task<HFlowdataModel> UpdateHFlowdata(HFlowdataModel HFlowdata);
        Task<HFlowdataModel> GetByFilterOrigin(Expression<Func<HFlowdataEntity, bool>> filter = null);
    }
}

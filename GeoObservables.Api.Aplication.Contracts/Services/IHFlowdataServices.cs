using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.Aplication.Contracts.Services
{
    public interface IHFlowdataServices
    {
        Task<double> GetHFlowdata(int idHData);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.DataAccess.Contracts.Entities;

namespace GeoObservables.Api.DataAccess.Contracts.Repositories
{
    public interface IHFlowdataRepository : IRepository<HFlowdataEntity>
    {
        Task<IEnumerable<HFlowdataEntity>> GetByFilter(Expression<Func<HFlowdataEntity, bool>> filter = null);
    }
}

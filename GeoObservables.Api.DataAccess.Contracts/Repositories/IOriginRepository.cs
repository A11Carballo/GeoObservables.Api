using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.DataAccess.Contracts.Entities;

namespace GeoObservables.Api.DataAccess.Contracts.Repositories
{
    public interface IOriginRepository : IRepository<OriginEntity>
    {
        Task<IEnumerable<OriginEntity>> GetByFilter(Expression<Func<OriginEntity, bool>> filter = null);
    }
}

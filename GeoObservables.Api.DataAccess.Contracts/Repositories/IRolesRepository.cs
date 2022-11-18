using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.DataAccess.Contracts.Entities;

namespace GeoObservables.Api.DataAccess.Contracts.Repositories
{
    public interface IRolesRepository : IRepository<RolesEntity>
    {
        Task<RolesEntity> GetByRol(string rol);
        Task<IEnumerable<RolesEntity>> GetByFilter(Expression<Func<RolesEntity, bool>> filter = null);
    }
}

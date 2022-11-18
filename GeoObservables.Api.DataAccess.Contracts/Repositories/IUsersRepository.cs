using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.DataAccess.Contracts.Entities;

namespace GeoObservables.Api.DataAccess.Contracts.Repositories
{
    public interface IUsersRepository : IRepository<UsersEntity>
    {
        Task<UsersEntity> GetUserByMail(string Mail);
        Task<UsersEntity> Deactivate(string mail);
        Task<IEnumerable<UsersEntity>> GetByFilter(Expression<Func<UsersEntity, bool>> filter = null);
    }
}

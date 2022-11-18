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
    public interface IOriginServices
    {
        Task<OriginModel> GetOrigin(int idOrigin);
        Task<OriginModel> AddOrigin(OriginModel origin);
        Task<IEnumerable<OriginModel>> GetAllOrigins();
        Task<bool> DeleteOrigin(int idOrigin);
        Task<OriginModel> UpdateOrigin(OriginModel origin);
        Task<bool> ExistOrigin(int idRol);
        Task<OriginModel> GetByFilterOrigin(Expression<Func<OriginEntity, bool>> filter = null);
    }
}

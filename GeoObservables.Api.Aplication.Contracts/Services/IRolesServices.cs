using System.Linq.Expressions;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Entities;

namespace GeoObservables.Api.Aplication.Contracts.Services
{
    public interface IRolesServices
    {
        Task<RolesModel> GetRol(int idRol);
        Task<RolesModel> AddRol(RolesModel rol);
        Task<IEnumerable<RolesModel>> GetAllRoles();
        Task<bool> DeleteRol(RolesModel rol);
        Task<RolesModel> UpdateRol(RolesModel rol);
        Task<RolesModel> GetRolByRol(string roll);
        Task<bool> ExistRol(int idRol);
        Task<bool> DeleteRolRequest(int id);
        Task<RolesModel> GetRolRequest(int id);
        Task<RolesModel> GetByFilterRol(Expression<Func<RolesEntity, bool>> filter = null);
    }
}

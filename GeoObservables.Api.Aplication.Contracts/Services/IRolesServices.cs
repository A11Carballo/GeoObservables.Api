using GeoObservables.Api.Business.Models;

namespace GeoObservables.Api.Aplication.Contracts.Services
{
    public interface IRolesServices
    {
        Task<RolesModel> GetRol(RolesModel rol);
        Task<RolesModel> AddRol(RolesModel rol);
        Task<IEnumerable<RolesModel>> GetAllRoles();
        Task<bool> DeleteRol(RolesModel rol);
        Task<RolesModel> UpdateRol(RolesModel rol);
        Task<RolesModel> GetRolByRol(string roll);
        Task<bool> ExistRol(int idRol);
        Task<bool> DeleteRolRequest(int id);
        Task<RolesModel> GetRolRequest(int id);
    }
}

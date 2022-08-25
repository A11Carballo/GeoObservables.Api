using GeoObservables.Api.Business.Models;

namespace GeoObservables.Api.Aplication.Contracts.Services
{
    public interface IRolesServices
    {
        Task<RolesModel> GetRol(int idRol);
        Task<RolesModel> AddRol(RolesModel rol);
        Task<IEnumerable<RolesModel>> GetAllRoles();
        Task<bool> DeleteRol(int idRol);
        Task<RolesModel> UpdateRol(RolesModel rol);
    }
}

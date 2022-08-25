using GeoObservables.Api.Business.Models;
using GeoObservables.Api.ViewModels;

namespace GeoObservables.Api.Mappers
{
    public class RolesMapper
    {
        public static RolesViewModel Map(RolesModel dto)
        {
            return new RolesViewModel()
            {
                Id = dto.Id,
                Role = dto.Role
            };
        }

        public static RolesModel Map(RolesViewModel dto)
        {
            return new RolesModel()
            {
                Id = dto.Id,
                Role = dto.Role
            };
        }
    }
}

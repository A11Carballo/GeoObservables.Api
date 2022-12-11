using GeoObservables.Api.Business.Models;
using GeoObservables.Api.ViewModels;

namespace GeoObservables.Api.Mappers
{
    public class RolesMapper
    {
        public static RolesViewModel? Map(RolesModel dto)
        {
            return dto == null ? null : new RolesViewModel()
            {
                Id = dto.Id,
                Role = dto.Role
            };
        }

        public static RolesModel? Map(RolesViewModel dto)
        {
            return dto == null ? null : new RolesModel()
            {
                Id = dto.Id,
                Role = dto.Role
            };
        }

    }
}

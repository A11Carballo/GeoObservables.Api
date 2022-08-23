using GeoObservables.Api.Business.Models;
using GeoObservables.Api.ViewModels;

namespace GeoObservables.Api.Mappers
{
    public class UsersMapper
    {
        public static UsersViewModel Map(UsersModel dto)
        {
            return new UsersViewModel()
            {
                Id = dto.Id,
                User = dto.User,
                Mail = dto.Mail,
                Password = dto.Password,
                DateCreated = dto.DateCreated,
                DateModified = dto.DateModified,
                IdRole = dto.IdRole,
                Description = dto.Description,
                Active = dto.Active
            };
        }

        public static UsersModel Map(UsersViewModel dto)
        {
            return new UsersModel()
            {
                Id = dto.Id,
                User = dto.User,
                Mail = dto.Mail,
                Password = dto.Password,
                DateCreated = dto.DateCreated,
                DateModified = dto.DateModified,
                IdRole = dto.IdRole,
                Description = dto.Description,
                Active = dto.Active
            };
        }
    }
}

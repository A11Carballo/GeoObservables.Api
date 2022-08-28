using GeoObservables.Api.Business.Models;
using GeoObservables.Api.ViewModels;

namespace GeoObservables.Api.Mappers
{
    public class UsersMapper
    {
        private static int rolusuario = 4;
        public static UsersViewModel? Map(UsersModel dto)
        {
            if (dto.IdRole != null && dto.IdRole != 0) { rolusuario = dto.IdRole; };

            return dto == null ? null : new UsersViewModel()
            {
                Id = dto.Id,
                User = dto.User,
                Mail = dto.Mail,
                Password = dto.Password,
                DateCreated = dto.DateCreated,
                DateModified = dto.DateModified,
                IdRole = rolusuario,
                Description = dto.Description,
                Active = dto.Active
            };
        }

        public static UsersModel? Map(UsersViewModel dto)
        {
            if (dto.IdRole != null && dto.IdRole != 0) { rolusuario = dto.IdRole; };

            return dto == null ? null : new UsersModel()
            {
                Id = dto.Id,
                User = dto.User,
                Mail = dto.Mail,
                Password = dto.Password,
                DateCreated = dto.DateCreated,
                DateModified = dto.DateModified,
                IdRole = rolusuario,
                Description = dto.Description,
                Active = dto.Active
            };
        }
    }
}

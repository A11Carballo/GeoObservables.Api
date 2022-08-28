using GeoObservables.Api.Business.Models;
using GeoObservables.Api.ViewModels;

namespace GeoObservables.Api.Mappers
{
    /// <summary>
    /// Convertir el LoginModel a UserDTO.
    /// </summary>
    public static class LoginUserMapper
    {
        public static UsersModel? Map(LoginViewModel model)
        {
            return model == null ? null : new UsersModel()
            {
                Mail = model.Mail,
                Password = model.Password,
                Description = model.Description
            };
        }

        public static LoginViewModel? Map(UsersModel dto)
        {
            return dto == null ? null : new LoginViewModel()
            {
                //Name = dto.Name,
                Mail = dto.Mail,
                Password = dto.Password,
                Description = dto.Description,
                Rol = dto.Roles.Role

            };
        }
    }
}

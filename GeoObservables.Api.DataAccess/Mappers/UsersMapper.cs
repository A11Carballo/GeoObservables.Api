using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Entities;

namespace GeoObservables.Api.DataAccess.Mappers
{
    public static class UsersMapper
    {
        public static UsersEntity Map(UsersModel dto)
        {
            return new UsersEntity()
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

        public static UsersModel Map(UsersEntity dto)
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

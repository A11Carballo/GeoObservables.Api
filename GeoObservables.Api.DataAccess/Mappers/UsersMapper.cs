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
        private static int rolusuario = 4;
        public static UsersEntity? Map(UsersModel dto)
        {
            if (dto.IdRole != null && dto.IdRole != 0) { rolusuario = dto.IdRole; };

            RolesEntity? rolesEntity = RolesMapper.Map(new RolesModel());
            return dto == null ? null : new UsersEntity()
            {
                Id = dto.Id,
                User = dto.User ?? "NoUserName",
                Mail = dto.Mail,
                Password = dto.Password,
                DateCreated = dto.DateCreated,
                DateModified = dto.DateModified,
                IdRole = rolusuario,
                Description = dto.Description,
                Active = dto.Active,
                Roles = RolesMapper.Map(dto.Roles)
            };
        }

        public static UsersModel? Map(UsersEntity dto)
        {
            if (dto.IdRole != null && dto.IdRole != 0) { rolusuario = dto.IdRole; };

            return dto == null ? null : new UsersModel()
            {
                Id = dto.Id,
                User = dto.User ?? "NoUserName",
                Mail = dto.Mail,
                Password = dto.Password,
                DateCreated = dto.DateCreated,
                DateModified = dto.DateModified,
                IdRole = dto.IdRole,
                Description = dto.Description,
                Active = dto.Active,
                Roles = RolesMapper.Map(dto.Roles)
            };
        }
    }
}

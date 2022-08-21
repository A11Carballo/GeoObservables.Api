using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Entities;

namespace GeoObservables.Api.DataAccess.Mappers
{
    public class RolesMapper
    {
        public static RolesEntity Map(RolesModel dto)
        {
            return new RolesEntity()
            {
                Id = dto.Id,
                Role = dto.Role
            };
        }

        public static RolesModel Map(RolesEntity dto)
        {
            return new RolesModel()
            {
                Id = dto.Id,
                Role = dto.Role
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Entities;

namespace GeoObservables.Api.DataAccess.Mappers
{
    public class OriginMapper
    {
        public static OriginEntity Map(OriginModel dto)
        {
            return new OriginEntity()
            {
                Id = dto.Id,
                OriginInfo = dto.OriginInfo,
                Description = dto.Description
            };
        }

        public static OriginModel Map(OriginEntity dto)
        {
            return new OriginModel()
            {
                Id = dto.Id,
                OriginInfo = dto.OriginInfo,
                Description = dto.Description
            };
        }
    }
}

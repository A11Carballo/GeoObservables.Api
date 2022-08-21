using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Entities;

namespace GeoObservables.Api.DataAccess.Mappers
{
    public class HFlowdataMapper
    {
        public static HFlowdataEntity Map(HFlowdataModel dto)
        {
            return new HFlowdataEntity()
            {
                Id = dto.Id,
                idOrigin = dto.idOrigin,
                idUserCreate = dto.idUserCreate,
                Long = dto.Long,
                Lat = dto.Lat,
                Height = dto.Height,
                Hflow = dto.Hflow,
                Description = dto.Description,
                Datacreated = dto.Datacreated,
                Datamodified = dto.Datamodified
            };
        }

        public static HFlowdataModel Map(HFlowdataEntity dto)
        {
            return new HFlowdataModel()
            {
                Id = dto.Id,
                idOrigin = dto.idOrigin,
                idUserCreate = dto.idUserCreate,
                Long = dto.Long,
                Lat = dto.Lat,
                Height = dto.Height,
                Hflow = dto.Hflow,
                Description = dto.Description,
                Datacreated = dto.Datacreated,
                Datamodified = dto.Datamodified
            };
        }
    }
}

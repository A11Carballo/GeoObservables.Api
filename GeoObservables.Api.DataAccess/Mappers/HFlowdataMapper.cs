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
            if (dto == null)
                return new HFlowdataModel();

            return new HFlowdataModel()
            {
                Id = dto?.Id ?? 0,
                idOrigin = dto?.idOrigin ?? 0,
                idUserCreate = dto?.idUserCreate ?? 0,
                Long = dto?.Long ?? 0,
                Lat = dto?.Lat ?? 0,
                Height = dto?.Height ?? 0,
                Hflow = dto?.Hflow ?? 0,
                Description = dto?.Description,
                Datacreated = dto?.Datacreated ?? DateTime.MinValue,
                Datamodified = dto?.Datamodified ?? DateTime.MinValue
            };
        }
    }
}

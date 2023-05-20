using GeoObservables.Api.Business.Models;
using GeoObservables.Api.ViewModels;

namespace GeoObservables.Api.Mappers
{
    public class HFlowdataMapper
    {
        public static HFlowdataViewModel Map(HFlowdataModel dto)
        {
            return new HFlowdataViewModel()
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

        public static HFlowdataModel Map(HFlowdataViewModel dto)
        {
            if (dto == null)
                return new HFlowdataModel();

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

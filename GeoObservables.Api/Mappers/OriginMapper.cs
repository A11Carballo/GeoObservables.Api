using GeoObservables.Api.Business.Models;
using GeoObservables.Api.ViewModels;

namespace GeoObservables.Api.Mappers
{
    public class OriginMapper
    {
        public static OriginViewModel Map(OriginModel dto)
        {
            return new OriginViewModel()
            {
                Id = dto.Id,
                OriginInfo = dto.OriginInfo,
                Description = dto.Description
            };
        }

        public static OriginModel Map(OriginViewModel dto)
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

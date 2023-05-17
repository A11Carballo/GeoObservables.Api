using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.OriginHandlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllOriginQuery, List<OriginViewModel>>
    {
        private readonly IOriginServices _originServices;

        public GetAllUsersQueryHandler(IOriginServices originServices)
        {
            _originServices = originServices;
        }

        public async Task<List<OriginViewModel>> Handle(GetAllOriginQuery request, CancellationToken cancellationToken)
        {
            var originList = await _originServices.GetAllOrigins();
            return originList.Select(OriginMapper.Map).ToList();
        }
    }
}

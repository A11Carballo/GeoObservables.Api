using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Aplication.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.OriginHandlers
{
    public class GetOriginQueryHandler : IRequestHandler<GetOriginQuery, OriginViewModel>
    {
        private readonly IOriginServices _originServices;

        public GetOriginQueryHandler(IOriginServices originServices)
        {
            _originServices = originServices;
        }

        public async Task<OriginViewModel> Handle(GetOriginQuery request, CancellationToken cancellationToken)
        {
            return OriginMapper.Map(await _originServices.GetOrigin(request.IdOrigin));
        }
    }
}

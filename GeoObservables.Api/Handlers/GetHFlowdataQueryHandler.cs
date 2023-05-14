using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers
{
    public class GetHFlowdataQueryHandler : IRequestHandler<GetHFlowdataQuery, HFlowdataViewModel>
    {
        private readonly IHFlowdataServices _hFlowdataServices;

        public GetHFlowdataQueryHandler(IHFlowdataServices hFlowdataServices)
        {
            _hFlowdataServices = hFlowdataServices;
        }

        public async Task<HFlowdataViewModel> Handle(GetHFlowdataQuery request, CancellationToken cancellationToken)
        {
            return HFlowdataMapper.Map(await _hFlowdataServices.GetHFlowdata(request.IdHFlow));
        }
    }
}

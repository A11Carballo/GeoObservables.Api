using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers
{
    public class GetAllHFlowdataQueryHandler : IRequestHandler<GetAllHFlowdataQuery, List<HFlowdataViewModel>>
    {
        private readonly IHFlowdataServices _hFlowdataServices;

        public GetAllHFlowdataQueryHandler(IHFlowdataServices hFlowdataServices)
        {
            _hFlowdataServices = hFlowdataServices;
        }

        public async Task<List<HFlowdataViewModel>> Handle(GetAllHFlowdataQuery request, CancellationToken cancellationToken)
        {
            var hFlowdataList = await _hFlowdataServices.GetAllHFlows();
            return hFlowdataList.Select(HFlowdataMapper.Map).ToList();
        }
    }
}

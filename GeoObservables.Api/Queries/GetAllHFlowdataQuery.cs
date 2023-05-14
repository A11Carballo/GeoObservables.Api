using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Queries
{
    public class GetAllHFlowdataQuery : IRequest<List<HFlowdataViewModel>>
    {
        // No additional properties needed
    }
}

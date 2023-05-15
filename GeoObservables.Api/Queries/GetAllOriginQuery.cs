using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Queries
{
    public class GetAllOriginQuery : IRequest<List<OriginViewModel>>
    {
        // No additional properties needed
    }
}

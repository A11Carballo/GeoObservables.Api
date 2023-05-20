using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Queries
{
    public class GetAllRolesQuery : IRequest<List<RolesViewModel>>
    {
        // No additional properties needed
    }
}

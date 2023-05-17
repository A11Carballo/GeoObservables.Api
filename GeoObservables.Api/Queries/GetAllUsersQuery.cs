using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Queries
{
    public class GetAllUsersQuery : IRequest<List<UsersViewModel>>
    {
        // No additional properties needed
    }
}

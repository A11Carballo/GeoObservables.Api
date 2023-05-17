using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Queries
{
    public class GetUsersQuery : IRequest<UsersViewModel>
    {
        public int IdUsers { get; set; }
    }
}

using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Queries
{
    public class GetRolesQuery : IRequest<RolesViewModel>
    {
        public int IdRoles { get; set; }
    }
}

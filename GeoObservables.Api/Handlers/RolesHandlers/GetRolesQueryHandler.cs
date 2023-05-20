using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.RolesHandlers
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, RolesViewModel>
    {
        private readonly IRolesServices _rolesServices;

        public GetRolesQueryHandler(IRolesServices rolesServices)
        {
            _rolesServices = rolesServices;
        }

        public async Task<RolesViewModel> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return RolesMapper.Map(await _rolesServices.GetRol(request.IdRoles));
        }
    }
}

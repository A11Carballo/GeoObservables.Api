using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.RolesHandlers
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RolesViewModel>>
    {
        private readonly IRolesServices _rolesServices;

        public GetAllRolesQueryHandler(IRolesServices rolesServices)
        {
            _rolesServices = rolesServices;
        }

        public async Task<List<RolesViewModel>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var originList = await _rolesServices.GetAllRoles();
            return originList.Select(RolesMapper.Map).ToList();
        }
    }
}

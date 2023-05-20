using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.RolesCommands;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.RolesHandlers
{
    public class UpdateRolesCommandHandler : IRequestHandler<UpdateRolesCommand, RolesViewModel>
    {
        private readonly IRolesServices _rolesServices;

        public UpdateRolesCommandHandler(IRolesServices rolesServices)
        {
            _rolesServices = rolesServices;
        }

        public async Task<RolesViewModel> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
        {
            return RolesMapper.Map(await _rolesServices.UpdateRol(RolesMapper.Map(request.Roles)));
        }
    }

}

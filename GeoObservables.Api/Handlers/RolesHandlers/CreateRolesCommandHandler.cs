using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.RolesCommands;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.RolesHandlers
{
    public class CreateRolesCommandHandler : IRequestHandler<CreateRolesCommand, RolesViewModel>
    {
        private readonly IRolesServices _rolesServices;

        public CreateRolesCommandHandler(IRolesServices rolesServices)
        {
            _rolesServices = rolesServices;
        }

        public async Task<RolesViewModel> Handle(CreateRolesCommand request, CancellationToken cancellationToken)
        {
            return RolesMapper.Map(await _rolesServices.AddRol(RolesMapper.Map(request.Roles)));
        }
    }

}

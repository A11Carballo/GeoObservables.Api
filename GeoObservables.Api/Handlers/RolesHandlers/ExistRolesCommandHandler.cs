using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.RolesCommands;
using MediatR;

namespace GeoObservables.Api.Handlers.RolesHandlers
{
    public class ExistRolesCommandHandler : IRequestHandler<ExistRolesCommand, bool>
    {
        private readonly IRolesServices _rolesServices;

        public ExistRolesCommandHandler(IRolesServices rolesServices)
        {
            _rolesServices = rolesServices;
        }

        public async Task<bool> Handle(ExistRolesCommand request, CancellationToken cancellationToken)
        {
            return await _rolesServices.ExistRol(request.IdRoles);
        }
    }

}

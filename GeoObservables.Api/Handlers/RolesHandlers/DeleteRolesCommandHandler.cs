using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.RolesCommands;
using MediatR;

namespace GeoObservables.Api.Handlers.RolesHandlers
{
    public class DeleteRolesCommandHandler : IRequestHandler<DeleteRolesCommand, bool>
    {
        private readonly IRolesServices _rolesServices;

        public DeleteRolesCommandHandler(IRolesServices rolesServices)
        {
            _rolesServices = rolesServices;
        }

        public async Task<bool> Handle(DeleteRolesCommand request, CancellationToken cancellationToken)
        {
            return await _rolesServices.DeleteRol(request.IdRoles);
        }
    }

}

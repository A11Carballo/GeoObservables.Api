using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.RolesCommands;
using MediatR;

namespace GeoObservables.Api.Handlers.RolesHandlers
{
    public class DeleteRolesCommandHandler : IRequestHandler<DeleteRolesCommand, bool>
    {
        private readonly IRolesServices _rolesServices;

        private readonly ILogger<DeleteRolesCommandHandler> _logger;

        public DeleteRolesCommandHandler(IRolesServices rolesServices, ILogger<DeleteRolesCommandHandler> logger)
        {
            _rolesServices = rolesServices;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteRolesCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"DeleteRolesCommand has been called.");

            return await _rolesServices.DeleteRol(request.IdRoles);
        }
    }

}

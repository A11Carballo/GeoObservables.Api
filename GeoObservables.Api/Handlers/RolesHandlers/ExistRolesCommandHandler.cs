using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.RolesCommands;
using MediatR;

namespace GeoObservables.Api.Handlers.RolesHandlers
{
    public class ExistRolesCommandHandler : IRequestHandler<ExistRolesCommand, bool>
    {
        private readonly IRolesServices _rolesServices;

        private readonly ILogger<ExistRolesCommandHandler> _logger;

        public ExistRolesCommandHandler(IRolesServices rolesServices, ILogger<ExistRolesCommandHandler> logger)
        {
            _rolesServices = rolesServices;
            _logger = logger;
        }

        public async Task<bool> Handle(ExistRolesCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"ExistRolesCommandHandler has been called.");

            return await _rolesServices.ExistRol(request.IdRoles);
        }
    }

}

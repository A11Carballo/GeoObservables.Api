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

        private readonly ILogger<CreateRolesCommandHandler> _logger;

        public CreateRolesCommandHandler(IRolesServices rolesServices, ILogger<CreateRolesCommandHandler> logger)
        {
            _rolesServices = rolesServices;
            _logger = logger;
        }

        public async Task<RolesViewModel> Handle(CreateRolesCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateRolesCommandHandler has been called.");

            return RolesMapper.Map(await _rolesServices.AddRol(RolesMapper.Map(request.Roles)));
        }
    }

}

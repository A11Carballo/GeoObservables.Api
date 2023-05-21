using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.UsersCommands;
using MediatR;

namespace GeoObservables.Api.Handlers.UsersHandlers
{
    public class ExistUsersCommandHandler : IRequestHandler<ExistUsersCommand, bool>
    {
        private readonly IUsersServices _usersServices;

        private readonly ILogger<ExistUsersCommandHandler> _logger;

        public ExistUsersCommandHandler(IUsersServices usersServices, ILogger<ExistUsersCommandHandler> logger)
        {
            _usersServices = usersServices;
            _logger = logger;   
        }

        public async Task<bool> Handle(ExistUsersCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"ExistUsersCommandHandler has been called.");

            return await _usersServices.ExistUsers(request.IdUsers);
        }
    }

}

using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.UsersCommands;
using MediatR;

namespace GeoObservables.Api.Handlers.UsersHandlers
{
    public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommand, bool>
    {
        private readonly IUsersServices _usersServices;

        private readonly ILogger<DeleteUsersCommandHandler> _logger;

        public DeleteUsersCommandHandler(IUsersServices usersServices, ILogger<DeleteUsersCommandHandler> logger)
        {
            _usersServices = usersServices;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"DeleteUsersCommand has been called.");

            return await _usersServices.DeleteUser(request.IdUsers);
        }
    }

}

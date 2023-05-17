using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.UsersCommands;
using MediatR;

namespace GeoObservables.Api.Handlers.UsersHandlers
{
    public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommand, bool>
    {
        private readonly IUsersServices _usersServices;

        public DeleteUsersCommandHandler(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        public async Task<bool> Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
        {
            return await _usersServices.DeleteUser(request.IdUsers);
        }
    }

}

using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.UsersCommands;
using MediatR;

namespace GeoObservables.Api.Handlers.UsersHandlers
{
    public class ExistUsersCommandHandler : IRequestHandler<ExistUsersCommand, bool>
    {
        private readonly IUsersServices _usersServices;

        public ExistUsersCommandHandler(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        public async Task<bool> Handle(ExistUsersCommand request, CancellationToken cancellationToken)
        {
            return await _usersServices.ExistUsers(request.IdUsers);
        }
    }

}

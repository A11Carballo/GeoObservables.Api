using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.UsersCommands;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.OUsersHandlers
{
    public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand, UsersViewModel>
    {
        private readonly IUsersServices _usersServices;

        public UpdateUsersCommandHandler(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        public async Task<UsersViewModel> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
        {
            return UsersMapper.Map(await _usersServices.UpdateUser(UsersMapper.Map(request.Users)));
        }
    }

}

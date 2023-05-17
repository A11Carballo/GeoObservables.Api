using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.UsersHandlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UsersViewModel>
    {
        private readonly IUsersServices _usersServices;

        public GetUsersQueryHandler(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        public async Task<UsersViewModel> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return UsersMapper.Map(await _usersServices.GetUser(request.IdUsers));
        }
    }
}

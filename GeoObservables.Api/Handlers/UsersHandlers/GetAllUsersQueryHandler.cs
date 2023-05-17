using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.UsersHandlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UsersViewModel>>
    {
        private readonly IUsersServices _usersServices;

        public GetAllUsersQueryHandler(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        public async Task<List<UsersViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var originList = await _usersServices.GetAllUsers();
            return originList.Select(UsersMapper.Map).ToList();
        }
    }
}

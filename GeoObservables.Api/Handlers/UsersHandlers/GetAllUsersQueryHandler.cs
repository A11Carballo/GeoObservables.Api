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

        private readonly ILogger<GetAllUsersQueryHandler> _logger;

        public GetAllUsersQueryHandler(IUsersServices usersServices, ILogger<GetAllUsersQueryHandler> logger)
        {
            _usersServices = usersServices;
            _logger = logger;   
        }

        public async Task<List<UsersViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetAllUsersQuery has been called.");

            var originList = await _usersServices.GetAllUsers();

            return originList.Select(UsersMapper.Map).ToList();
        }
    }
}

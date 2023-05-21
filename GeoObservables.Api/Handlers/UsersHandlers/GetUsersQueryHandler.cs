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

        private readonly ILogger<GetUsersQueryHandler> _logger;

        public GetUsersQueryHandler(IUsersServices usersServices, ILogger<GetUsersQueryHandler> logger)
        {
            _usersServices = usersServices;
            _logger = logger;
        }

        public async Task<UsersViewModel> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetUsersQuery has been called.");

            return UsersMapper.Map(await _usersServices.GetUser(request.IdUsers));
        }
    }
}

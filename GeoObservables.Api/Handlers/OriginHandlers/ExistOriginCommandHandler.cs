using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.OriginCommands;
using MediatR;

namespace GeoObservables.Api.Handlers.OriginHandlers
{
    public class ExistUsersCommandHandler : IRequestHandler<ExistOriginCommand, bool>
    {
        private readonly IOriginServices _originServices;

        public ExistUsersCommandHandler(IOriginServices originServices)
        {
            _originServices = originServices;
        }

        public async Task<bool> Handle(ExistOriginCommand request, CancellationToken cancellationToken)
        {
            return await _originServices.ExistOrigin(request.IdOrigin);
        }
    }

}

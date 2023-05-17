using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.OriginCommands;
using MediatR;

namespace GeoObservables.Api.Handlers.OriginHandlers
{
    public class DeleteUsersCommandHandler : IRequestHandler<DeleteOriginCommand, bool>
    {
        private readonly IOriginServices _originServices;

        public DeleteUsersCommandHandler(IOriginServices originServices)
        {
            _originServices = originServices;
        }

        public async Task<bool> Handle(DeleteOriginCommand request, CancellationToken cancellationToken)
        {
            return await _originServices.DeleteOrigin(request.IdOrigin);
        }
    }

}

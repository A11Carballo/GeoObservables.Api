using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.OriginCommands;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.OriginHandlers
{
    public class UpdateUsersCommandHandler : IRequestHandler<UpdateOriginCommand, OriginViewModel>
    {
        private readonly IOriginServices _originServices;

        public UpdateUsersCommandHandler(IOriginServices originServices)
        {
            _originServices = originServices;
        }

        public async Task<OriginViewModel> Handle(UpdateOriginCommand request, CancellationToken cancellationToken)
        {
            return OriginMapper.Map(await _originServices.UpdateOrigin(OriginMapper.Map(request.Origin)));
        }
    }

}

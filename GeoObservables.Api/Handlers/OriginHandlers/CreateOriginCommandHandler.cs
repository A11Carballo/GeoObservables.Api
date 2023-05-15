using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Aplication.Services;
using GeoObservables.Api.Commands.HFlowCommands;
using GeoObservables.Api.Commands.OriginCommands;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.OriginHandlers
{
    public class CreateOriginCommandHandler : IRequestHandler<CreateOriginCommand, OriginViewModel>
    {
        private readonly IOriginServices _originServices;

        public CreateOriginCommandHandler(IOriginServices originServices)
        {
            _originServices = originServices;
        }

        public async Task<OriginViewModel> Handle(CreateOriginCommand request, CancellationToken cancellationToken)
        {
            return OriginMapper.Map(await _originServices.AddOrigin(OriginMapper.Map(request.Origin)));
        }
    }

}

using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.HFlowCommands;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using MediatR;

namespace GeoObservables.Api.Handlers.HFHandlers
{
    public class UpdateOriginCommandHandler : IRequestHandler<UpdateHFlowdataCommand, HFlowdataViewModel>
    {
        private readonly IHFlowdataServices _hFlowdataServices;

        public UpdateOriginCommandHandler(IHFlowdataServices hFlowdataServices)
        {
            _hFlowdataServices = hFlowdataServices;
        }

        public async Task<HFlowdataViewModel> Handle(UpdateHFlowdataCommand request, CancellationToken cancellationToken)
        {
            var updatedHFlowdata = await _hFlowdataServices.UpdateHFlowdata(HFlowdataMapper.Map(request.HFlowdata));
            return HFlowdataMapper.Map(updatedHFlowdata);
        }
    }

}

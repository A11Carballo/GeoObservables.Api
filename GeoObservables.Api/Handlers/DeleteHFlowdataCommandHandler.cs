using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Commands.HFlowCommands;
using MediatR;

namespace GeoObservables.Api.Handlers
{
    public class DeleteHFlowdataCommandHandler : IRequestHandler<DeleteHFlowdataCommand, bool>
    {
        private readonly IHFlowdataServices _hFlowdataServices;

        public DeleteHFlowdataCommandHandler(IHFlowdataServices hFlowdataServices)
        {
            _hFlowdataServices = hFlowdataServices;
        }

        public async Task<bool> Handle(DeleteHFlowdataCommand request, CancellationToken cancellationToken)
        {
            return await _hFlowdataServices.DeleteHFlowdata(request.IdHFlow);
        }
    }

}

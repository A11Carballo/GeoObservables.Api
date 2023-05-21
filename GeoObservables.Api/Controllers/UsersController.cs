using GeoObservables.Api.Commands.UsersCommands;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.Queries;
using GeoObservables.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace GeoObservables.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        private readonly IMediator _mediator;

        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        //CRUD

        /// <summary>
        /// GET User
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(UsersViewModel))]
        [HttpGet("{idUser}")]
        public async Task<UsersViewModel> Get(int idUser) =>
             await _mediator.Send(new GetUsersQuery { IdUsers = idUser });

        /// <summary>
        /// POST User
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(UsersViewModel))]
        [HttpPost]
        public async Task<UsersViewModel> AddUsers([FromBody] UsersViewModel users) =>
            await _mediator.Send(new CreateUsersCommand { Users = users });

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(bool))]
        [HttpDelete("{idUser}")]
        public async Task<bool> DeleteUser(int idUser) => await _mediator.Send(new DeleteUsersCommand { IdUsers = idUser }); 

        /// <summary>
        /// PUT User
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(UsersViewModel))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(UsersViewModel))]
        [HttpPut]
        public async Task<UsersViewModel> UpdateUsers([FromBody] UsersViewModel users) =>
                       await _mediator.Send(new UpdateUsersCommand { Users = users });

        /// <summary>
        /// GET All Users
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(List<UsersViewModel>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UsersViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<UsersViewModel>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(List<UsersViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<UsersViewModel>))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(List<UsersViewModel>))]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers() => Ok(await _mediator.Send(new GetAllUsersQuery()));

        /// <summary>
        /// Deactivate User
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(bool))]
        [HttpPut("Deactivate/{mail}")]
        public async Task<UsersViewModel> DeactivateUser(string mail) => await _mediator.Send(new DeactivateUsersCommand { Mail = mail });

        /// <summary>
        /// Exist User
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(bool))]
        [HttpGet("exist/{idUser}")]
        public async Task<bool> ExistUsers(int idUser) => await _mediator.Send(new ExistUsersCommand { IdUsers = idUser }); 
    }

}

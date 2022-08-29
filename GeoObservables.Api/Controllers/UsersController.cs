using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeoObservables.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        private readonly IUsersServices _usersServices;

        public UsersController(ILogger<UsersController> logger, IUsersServices usersServices)
        {
            _logger = logger;
            _usersServices= usersServices;
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
             UsersMapper.Map(await _usersServices.GetUser(idUser));

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
            UsersMapper.Map(await _usersServices.AddUser(UsersMapper.Map(users)));

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
        public async Task<bool> DeleteUser(int idUser) => await _usersServices.DeleteUser(idUser);

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
            UsersMapper.Map(await _usersServices.UpdateUser(UsersMapper.Map(users)));


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
        public async Task<IActionResult> GetAllUsers() =>
             Ok(await _usersServices.GetAllUsers());

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
        public async Task<UsersViewModel> DeactivateUser(string mail) => UsersMapper.Map(await _usersServices.Deactivate(mail));

    }

}

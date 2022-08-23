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
        /// GET api/model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(UsersViewModel))]
        [HttpGet("{id}")]
        public async Task<UsersViewModel> Get(int id) =>
             UsersMapper.Map(await _usersServices.GetUser(id));

        /// <summary>
        /// POST api/model
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(UsersViewModel))]
        [HttpPost]
        public async Task<UsersViewModel> AddUsers([FromBody] UsersViewModel users) => 
            UsersMapper.Map(await _usersServices.AddUser(UsersMapper.Map(users)));


    }
}

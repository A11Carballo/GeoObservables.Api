using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Mappers;
using GeoObservables.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GeoObservables.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUsersServices _userService;
        private readonly IAppConfig _appConfig;
        private readonly IRolesServices _rolesServices;

        //Podemos inyectar los servicios que queramos por controlador.

        public LoginController(IUsersServices userService, IAppConfig appConfig, IRolesServices rolesServices)
        {
            _userService = userService;
            _appConfig = appConfig;
            _rolesServices = rolesServices;
        }


        /// <summary>
        /// Acceso Geo Login
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [Produces("application/json", Type = typeof(LoginViewModel))]
        [HttpGet("{mail}/{password}")]
        public async Task<IActionResult> Login(string mail, string password)
        {
            //Accedemos al service para obtener el usuario.
            var user = await _userService.GetInternalLogin(mail, password);


            // var info = await SigninManager.GetExternalLoginInfoAsync();

            if (user != null)
            {
                //var token = _loginService.CreateKeys(user);
                //create claims details based on the user information
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _appConfig.JwtSubject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(ClaimTypes.Role, user.Roles.Role),
                    new Claim(ClaimTypes.Email, user.Mail)
                    };

                // save in a session 
                HttpContext.Session.SetString("SKEY", user.Mail);

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_appConfig.JwtKey));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_appConfig.JwtIssuer, _appConfig.JwtAudience, claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                //Error login
                return BadRequest();
            }
        }

        /// <summary>
        /// Create login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>User</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json", Type = typeof(LoginViewModel))]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] LoginViewModel login)
        {
            var RolUser = _rolesServices.GetRolByRol(login.Rol).Result;

            if (RolUser == null || RolUser.Id > _rolesServices.GetAllRoles().Result.LastOrDefault().Id || RolUser.Id == 0)
                throw new ArgumentNullException();

            var ip = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First().ToString();
            var userMod = LoginUserMapper.Map(await _userService.CreateInternalUser(login.User, login.Mail, login.Password, ip, RolUser.Id, login.Description));

            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _appConfig.JwtSubject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(ClaimTypes.Role, login.Rol),
                    new Claim(ClaimTypes.Email, login.Mail)
                    };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_appConfig.JwtKey));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_appConfig.JwtIssuer, _appConfig.JwtAudience, claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            //Pero la salida devolvemos el token.            
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        /// <summary>
        /// Deactivate Geo Login
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [Produces("application/json", Type = typeof(LoginViewModel))]
        [HttpPut("Deactivate/{mail}/{password}")]
        public async Task<UsersViewModel> DeactivateInternalLogin(string mail, string password) =>
             UsersMapper.Map(await _userService.DeactivateInternalLogin(mail, password));

    }
}

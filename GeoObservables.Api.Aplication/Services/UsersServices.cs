using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Aplication.Login;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Entities;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;
using GeoObservables.Api.DataAccess.Repositories;
using Microsoft.Extensions.Logging;
using Polly;
using Serilog.Core;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace GeoObservables.Api.Aplication.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IAppConfig _appConfig;
        private readonly int _maxTrys;
        private readonly TimeSpan _timeToWait;
        private readonly IUsersRepository _usersRepository;
        private readonly IRolesServices _rolesServices;
        private readonly ILogger<UsersServices> _logger;

        public UsersServices(IUsersRepository usersRepository, IAppConfig appConfig, IRolesServices rolesServices, ILogger<UsersServices> logger)
        {
            this._usersRepository = usersRepository;

            this._appConfig = appConfig;

            this._rolesServices = rolesServices;

            this._maxTrys = _appConfig.MaxTrys();

            this._timeToWait = TimeSpan.FromSeconds(_appConfig.SecondsToWait());

            this._logger = logger;
        }

        public async Task<UsersModel> GetUser(int idUser)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"GetUser {idUser} User");

                return UsersMapper.Map(await _usersRepository.Get(idUser));
            });
        }

        public async Task<UsersModel> Deactivate(string mail)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"Deactivate {mail} mail");

                return UsersMapper.Map(await _usersRepository.Deactivate(mail));
            });
        }

        public async Task<UsersModel> AddUser(UsersModel user)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"AddUser {user} User");

                return UsersMapper.Map(await _usersRepository.Add(UsersMapper.Map(user)));
            });
        }

       public async Task<IEnumerable<UsersModel>> GetAllUsers()
       {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"GetAllUsers");

                return (await _usersRepository.GetAll()).Select(UsersMapper.Map);
            });
        }

        public async Task<UsersModel> UpdateUser(UsersModel user)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"UpdateUser {user} User");

                return UsersMapper.Map(await _usersRepository.Update(UsersMapper.Map(user)));
            });
        }

        public async Task<bool> DeleteUser(int idUser)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"DeleteUser {idUser} User");

                return await _usersRepository.DeleteAsyncBool(idUser);
            });
        }

        public async Task<UsersModel> GetInternalLogin(string mail, string password)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password))
                return null;

            return await retryPolity.ExecuteAsync(async () =>
            {
                try
                {
                    UsersModel? user = UsersMapper.Map(await _usersRepository.GetUserByMail(mail));
                    CustomPasswordHasher? customPasswordHasher = new CustomPasswordHasher();

                    if (customPasswordHasher.VerifyPassword(user.Password, password))
                    {
                        this._logger.LogInformation($"GetUserByMail {mail} mail");

                        return user;
                    }
                    else
                    {
                        // Login Failed
                        this._logger.LogInformation($"GetUserByMail {mail} mail --> Login Failed");

                        return null;
                    }
                }
                catch (Exception e)
                {
                    //Por si falla el mapper porque devuelva nullo el user o cualquier otro motivo.
                    this._logger.LogInformation($"GetUserByMail {mail} mail --> Login Failed, mapper, null return...");

                    return null;
                }

            });
        }

        public async Task<UsersModel> CreateInternalUser(string name, string mail, string password, string Ip, int rol, string description)
        {

            //Controlamos cualquier tipo de excepción y reintentamos las veces que nos marque la configuración.
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"CreateInternalUser {mail} mail and {password} password");

                var customPasswordHasher = new CustomPasswordHasher();

                var passwordHas = customPasswordHasher.HashPassword(password);

                //var RolDto = await _rolesServices.GetRol(rol) ?? new RolesModel();

                UsersModel user = new UsersModel(name, passwordHas, mail, rol, description, true);

                var addedEntity = await _usersRepository.Add(UsersMapper.Map(user));

                return UsersMapper.Map(addedEntity);
            });

        }

        public async Task<UsersModel> DeactivateInternalLogin(string mail, string password)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password))
                return null;

            return await retryPolity.ExecuteAsync(async () =>
            {
                try
                {
                    UsersModel? user = UsersMapper.Map(await _usersRepository.GetUserByMail(mail));
                    CustomPasswordHasher? customPasswordHasher = new CustomPasswordHasher();

                    if (customPasswordHasher.VerifyPassword(user.Password, password))
                    {
                        this._logger.LogInformation($"DeactivateInternalLogin {mail} mail and {password} password");
                        return UsersMapper.Map(await _usersRepository.Deactivate(mail));
                    }
                    else
                    {
                        // Verification Failed
                        this._logger.LogInformation($"DeactivateInternalLogin {mail} mail and {password} password --> Verification Failed");
                        return null;
                    }
                }
                catch (Exception e)
                {
                    //Por si falla el mapper porque devuelva nullo el user o cualquier otro motivo.
                    this._logger.LogInformation($"DeactivateInternalLogin {mail} mail and {password} password --> Login Failed, mapper, null return...");
                    return null;
                }

            });

        }
        public async Task<bool> ExistUsers(int idUser)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                this._logger.LogInformation($"ExistUsers {idUser} mail");

                return await _usersRepository.Exist(idUser);
            });
        }

        public async Task<UsersModel> GetByFilterUsers(Expression<Func<UsersEntity, bool>> filter = null)
        {

            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                var UsersFilter = await _usersRepository.GetByFilter(filter);

                this._logger.LogInformation($"GetByFilterUsers {filter} filter");

                return UsersMapper.Map(UsersFilter.First());
            });

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Aplication.Login;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;
using Polly;

namespace GeoObservables.Api.Aplication.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IAppConfig _appConfig;
        private readonly int _maxTrys;
        private readonly TimeSpan _timeToWait;
        private readonly IUsersRepository _usersRepository;
        private readonly IRolesServices _rolesServices;
        public UsersServices(IUsersRepository usersRepository, IAppConfig appConfig, IRolesServices rolesServices)
        {
            _usersRepository = usersRepository;
            _appConfig = appConfig;
            _rolesServices = rolesServices;

            _maxTrys = _appConfig.MaxTrys();
            _timeToWait = TimeSpan.FromSeconds(_appConfig.SecondsToWait());
        }

        public async Task<UsersModel> GetUser(int idUser)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return UsersMapper.Map(await _usersRepository.Get(idUser));
            });
        }

        public async Task<UsersModel> Deactivate(string mail)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return UsersMapper.Map(await _usersRepository.Deactivate(mail));
            });
        }

        public async Task<UsersModel> AddUser(UsersModel user)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return UsersMapper.Map(await _usersRepository.Add(UsersMapper.Map(user)));
            });
        }

       public async Task<IEnumerable<UsersModel>> GetAllUsers()
       {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return (await _usersRepository.GetAll()).Select(UsersMapper.Map);
            });
        }

        public async Task<UsersModel> UpdateUser(UsersModel user)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
                return UsersMapper.Map(await _usersRepository.Update(UsersMapper.Map(user)));
            });
        }

        public async Task<bool> DeleteUser(int idUser)
        {
            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(_maxTrys, i => _timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {
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
                        return user;
                    }
                    else
                    {
                        // Login Failed
                        return null;
                    }
                }
                catch (Exception e)
                {
                    //Por si falla el mapper porque devuelva nullo el user o cualquier otro motivo.
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
                        return UsersMapper.Map(await _usersRepository.Deactivate(mail));
                    }
                    else
                    {
                        // Verification Failed
                        return null;
                    }
                }
                catch (Exception e)
                {
                    //Por si falla el mapper porque devuelva nullo el user o cualquier otro motivo.
                    return null;
                }

            });
        }
    }
}

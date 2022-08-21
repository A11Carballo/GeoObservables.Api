using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Business.Models;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Mappers;

namespace GeoObservables.Api.Aplication.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepository _usersRepository;
        public UsersServices(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<string> GetUser(int idUser)
        {
            var User = await _usersRepository.Get(idUser);

            return User.User;
        }

        public async Task<UsersModel> AddUser(UsersModel user)
        {
            var addUser = await _usersRepository.Add(UsersMapper.Map(user));

            return UsersMapper.Map(addUser);
        }
    }
}

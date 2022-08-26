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
    public class UsersServices : Lazy<IUsersServices>
    {
        private readonly Lazy<IUsersRepository> _usersRepository;
        public UsersServices(Lazy<IUsersRepository> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UsersModel> GetUser(int idUser)
        {
            var User = await _usersRepository.Value.Get(idUser);

            return UsersMapper.Map(User);
        }

        public async Task<UsersModel> AddUser(UsersModel user)
        {
            var addUser = await _usersRepository.Value.Add(UsersMapper.Map(user));

            return UsersMapper.Map(addUser);
        }

       public async Task<IEnumerable<UsersModel>> GetAllUsers()
        {
            var allUsers = await _usersRepository.Value.GetAll();

            return allUsers.Select(UsersMapper.Map);
        }

        public async Task<UsersModel> UpdateUser(UsersModel user)
        {
            var updUser = await _usersRepository.Value.Update(UsersMapper.Map(user));

            return (UsersMapper.Map(updUser));
        }

        public async Task<bool> DeleteUser(int idUser)
        {
            var isDelete = await _usersRepository.Value.DeleteAsyncBool(idUser);

            return isDelete;
        }
    }
}

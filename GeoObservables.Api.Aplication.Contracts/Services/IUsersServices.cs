using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Business.Models;

namespace GeoObservables.Api.Aplication.Contracts.Services
{
    public interface IUsersServices
    {
        Task<UsersModel> GetUser(int idUser);
        Task<UsersModel> AddUser(UsersModel user);
        Task<IEnumerable<UsersModel>> GetAllUsers();
    }
}

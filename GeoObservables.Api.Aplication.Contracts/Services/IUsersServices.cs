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
        Task<bool> DeleteUser(int idUser);
        Task<UsersModel> UpdateUser(UsersModel user);
        Task<UsersModel> GetInternalLogin(string mail, string password);
        Task<UsersModel> CreateInternalUser(string name, string mail, string password, string Ip, int rol, string description);
        Task<UsersModel> Deactivate(string mail);
        Task<UsersModel> DeactivateInternalLogin(string mail, string password);
    }
}

using KanbanBoardBlazor.Server.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> getAllUsers();

        public bool ValidateCredentials(string username, string password);

        public User GetUserById(int id);

        public User GetUserByUsername(string username);

        public void RegisterUser(string username, string password);

        //public List<Role> GetUserRoles(int id);
    }
}

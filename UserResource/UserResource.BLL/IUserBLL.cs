using System.Collections.Generic;
using UserResource.DAL;
using UserResource.DAL.Entities;

namespace UserResource.BLL
{
    public interface IUserBLL
    {
        IEnumerable<User> GetUsers(Paging paging);
        User GetUserById(int userId);
        User CreateUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int userId);
    }
}
using System.Collections.Generic;
using UserResource.DAL.Entities;

namespace UserResource.DAL
{
    public interface IUserDAL
    {
        IEnumerable<User> Get(Paging paging);
        IEnumerable<User> Get(Paging paging, FilterCriteria filterCriteria);
        User Get(int userId);
        User Update(User user);
        User Create(User user);
        User Delete(int userId);
    }
}
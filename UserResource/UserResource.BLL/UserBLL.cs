using System.Collections.Generic;
using AutoMapper;
using ExternalSynchronization;
using UserResource.DAL;
using UserResource.DAL.Entities;

namespace UserResource.BLL
{
    public class UserBLL: IUserBLL
    {
        private readonly IUserDAL _userDal;
        private readonly IMapper _mapper;
        private readonly IExternalUserClient _externalClient;

        public UserBLL(IUserDAL userDal, IExternalUserClient externalClient, IMapper mapper)
        {
            _userDal = userDal;
            _externalClient = externalClient;
            _mapper = mapper;
        }

        public IEnumerable<User> GetUsers(Paging paging)
        {
            // Only return back current non-deleted users.
            var filterCriteria = new FilterCriteria()
            {
                Property = "IsDeleted",
                Value = "false"
            };

            var allUsers = _userDal.Get(paging, filterCriteria);
            return allUsers;
        }

        public User GetUserById(int userId)
        {
            return _userDal.Get(userId);
        }

        public User CreateUser(User user)
        {
            var createdUser = _userDal.Create(user);
            var externalUser = _mapper.Map<User, ExternalUser>(createdUser);

            // This should actually persist to an internal DB queue which would then on a process call the external client...
            var persistedUserToExternalSynchronization = _externalClient.Save(externalUser);
            return createdUser;
            
        }

        public User UpdateUser(User user)
        {
            return _userDal.Update(user);
        }

        public User DeleteUser(int userId)
        {
            throw new System.NotImplementedException();
        }

      
    }
}
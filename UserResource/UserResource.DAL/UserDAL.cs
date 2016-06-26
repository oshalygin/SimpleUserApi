using System.Collections.Generic;
using System.Linq;
using UserResource.DAL.Entities;

namespace UserResource.DAL
{
    public class UserDAL: IUserDAL
    {
        public IEnumerable<User> Get(Paging paging)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> Get(Paging paging, FilterCriteria filterCriteria)
        {
            return UserMockData().Where(x => x.IsDeleted).AsEnumerable();
        }

        public User Get(int userId)
        {
            return new User()
            {
                Id = userId,
                FirstName = "Oleg",
                LastName = "Shalygin",
                IsActive = true,
                UserContactInformation =
                    new UserContactInformation()
                    {
                        ContactType = ContactType.CellPhone,
                        ContactValue = "111-111-1111",
                        Id = 1
                    }
            };
        }

        public User Update(User user)
        {
            // The current record has the 'IsActive' flag set to false;
            // Insert a new record into the DB and return back this object.
            return user;
        }

        public User Create(User user)
        {
            // Insert a new record into the DB and return back this object.
            return user;
        }

        public User Delete(int userId)
        {
            // Get the User by Id
            // Mark the record 'IsDeleted' as true;
            // Returns the User object.
            return new User()
            {
                Id = userId,
                FirstName = "Oleg",
                LastName = "Shalygin",
                IsActive = true,
                IsDeleted = true,
                UserContactInformation =
                    new UserContactInformation()
                    {
                        ContactType = ContactType.CellPhone,
                        ContactValue = "111-111-1111",
                        Id = 1
                    }
            };
        }

        public User Delete(User user)
        {
            // Mark the record 'IsDeleted' as true;
            return user;
        }

        private IList<User> UserMockData()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "Oleg",
                    LastName = "Shalygin",
                    IsActive = true,
                    UserContactInformation =
                        new UserContactInformation()
                        {
                            ContactType = ContactType.CellPhone,
                            ContactValue = "111-111-1111",
                            Id = 1
                        }
                },
                new User()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    IsActive = true,
                    UserContactInformation =
                        new UserContactInformation()
                        {
                            ContactType = ContactType.Email,
                            ContactValue = "foobar@gmail.com",
                            Id = 2
                        }
                },
                new User()
                {
                    Id = 3,
                    FirstName = "Mary",
                    LastName = "Robinson",
                    IsActive = false,
                    UserContactInformation =
                        new UserContactInformation()
                        {
                            ContactType = ContactType.Email,
                            ContactValue = "foobar@gmail.com",
                            Id = 2
                        }
                }
            };
        }
    }
}
using System.Collections.Generic;
using UserResource.DAL.Entities;
using UserResource.Models;

namespace UserResource.Tests
{
    public static class Mother
    {
        public static int Page = 1;
        public static int PageSize = 10;

        public static IEnumerable<User> Users() => new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Oleg",
                LastName = "Shalygin",
                IsActive = true,
                UserContactInformation =
                    new UserContactInformation
                    {
                        ContactType = ContactType.CellPhone,
                        ContactValue = "111-111-1111",
                        Id = 1
                    }
            },
            new User
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                IsActive = true,
                UserContactInformation =
                    new UserContactInformation
                    {
                        ContactType = ContactType.Email,
                        ContactValue = "foobar@gmail.com",
                        Id = 2
                    }
            },
            new User
            {
                Id = 3,
                FirstName = "Mary",
                LastName = "Robinson",
                IsActive = false,
                UserContactInformation =
                    new UserContactInformation
                    {
                        ContactType = ContactType.Email,
                        ContactValue = "foobar@gmail.com",
                        Id = 2
                    }
            }
        };

        public static IEnumerable<UserViewModel> UsersViewModel() => new List<UserViewModel>
        {
            new UserViewModel
            {
                Id = 1,
                FirstName = "Oleg",
                LastName = "Shalygin",
                UserContactInformation =
                    new UserContactInformationViewModel
                    {
                        ContactType = 2,
                        ContactValue = "111-111-1111",
                        Id = 1
                    }
            },
            new UserViewModel
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                UserContactInformation =
                    new UserContactInformationViewModel
                    {
                        ContactType = 3,
                        ContactValue = "foobar@gmail.com",
                        Id = 2
                    }
            },
            new UserViewModel
            {
                Id = 3,
                FirstName = "Mary",
                LastName = "Robinson",
                UserContactInformation =
                    new UserContactInformationViewModel
                    {
                        ContactType = 2,
                        ContactValue = "foobar@gmail.com",
                        Id = 2
                    }
            }
        };
    }
}
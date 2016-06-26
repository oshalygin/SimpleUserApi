using System.Collections.Generic;
using UserResource.DAL;
using UserResource.DAL.Entities;

namespace UserResource.BLL.Tests
{
    public static class Mother
    {
        public static int Page = 1;
        public static int PageSize = 10;
        public static Paging Paging => new Paging()
        {
            Page = Page,
            PageSize = PageSize
        };

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

        public static User UserOleg => new User
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
        };
    }
}
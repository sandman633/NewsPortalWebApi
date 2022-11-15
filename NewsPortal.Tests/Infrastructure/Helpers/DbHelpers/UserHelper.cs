using NewsPortal.Model.Domain;
using System.Collections.Generic;
using System.Linq;

namespace TestWebApi.Infrastructure.Helpers.DbHelpers
{
    public static class UserHelper
    {
        public static User GetOne(int id=1)
        {
            return new User { 
                Id = id,
                Age = 1,
                Name = $"UserName {id}",
                Email = "Email@gmail.com",
                Password = "123!@#",
                PhoneNumber = "1234567",
                Surname = "Surname",
            };
        }
        public static IEnumerable<User> GetMany(int count = 1)
        {
            for (int i = 1; i <= count; i++)
            {
                yield return GetOne(i);
            }
        }
    }
}

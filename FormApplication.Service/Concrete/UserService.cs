using FormApplication.Core;
using FormApplication.Data.Contexts;
using FormApplication.Service.Abstract;
using PhoneBook.Data.Model.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormApplication.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly FormApplicationContext _db;

        public UserService(FormApplicationContext db)
        {
            _db = db;
        }
        public bool Login(UserDto user)
        {
            var isLogin = _db.Users.Any(t => t.Username == user.UserName && t.Password == user.Password);

            if (isLogin)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

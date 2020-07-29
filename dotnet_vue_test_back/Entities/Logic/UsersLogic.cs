using dotnet_vue_test_back.Entities.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace dotnet_vue_test_back.Entities.Logic
{
    public class UsersLogic
    {
        private readonly DB _db;

        public UsersLogic(DB dB)
        {
            _db = dB;
        }

        public IQueryable<User> GetUsers()
        {
            return _db.Users;
        }

        public void NewUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void EditUser(User user)
        {
            var row = _db.Users.FirstOrDefault(x => x.Id == user.Id);
            if (row != null)
            {
                row.FIO = user.FIO;
                row.BirthDate = user.BirthDate;
                row.Phone = user.Phone;

                _db.SaveChanges();
            }
        }
    }
}

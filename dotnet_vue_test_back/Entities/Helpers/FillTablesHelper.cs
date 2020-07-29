using dotnet_vue_test_back.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_vue_test_back.Entities.Helpers
{
    public class FillTablesHelper
    {
        public static FillTablesHelper Instance => new FillTablesHelper();

        private FillTablesHelper() { }

        public IEnumerable<User> FillUsers()
        {
            List<User> users = new List<User>();

            users.Add(new User() { Id = 1, FIO = "Курин Максим Евгеньевич", BirthDate = new DateTime(1995, 12, 5), Phone = "1233232143" });
            users.Add(new User() { Id = 2, FIO = "Харламов Яков Андреевич", BirthDate = new DateTime(1984, 8, 7), Phone = "3217457483" });
            users.Add(new User() { Id = 3, FIO = "Гурковский Артемий Несторович", BirthDate = new DateTime(2001, 4, 13), Phone = "4993689364" });
            users.Add(new User() { Id = 4, FIO = "Сереброва Анастасия Зиновьевна", BirthDate = new DateTime(1978, 3, 25), Phone = "8889574822" });

            return users;
        }
    }
}

using dotnet_vue_test_back.Entities.Logic;
using dotnet_vue_test_back.Entities.Tables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_vue_test_back.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UsersLogic _usersLogic;

        public UsersController(UsersLogic usersLogic)
        {
            _usersLogic = usersLogic;
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = _usersLogic.GetUsers().ToArray();
            return Json(users);
        }

        [HttpPost("new")]
        public void NewUser([FromBody] User user)
        {
            _usersLogic.NewUser(user);
        }

        [HttpPost("edit")]
        public void EditUser([FromBody] User user)
        {
            _usersLogic.EditUser(user);
        }
    }
}

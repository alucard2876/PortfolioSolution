using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioSolution.Buisness.UserServices;
using PortfolioSolution.Buisness.ViewModels;
using PortfolioSolution.Domain.Entitys;

namespace PortfolioSolution.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public UserViewModel GetUser(string userName, string password)
        {
            return _userService.GetUser(userName, password);
        }

        [HttpPost]
        public UserViewModel AddUser(UserViewModel userViewModel)
        {
            return _userService.AddUser(userViewModel);
        }
    }
}

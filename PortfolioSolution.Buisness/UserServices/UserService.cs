using PortfolioSolution.Buisness.ViewModels;
using PortfolioSolution.Domain.Entitys;
using PortfolioSolution.DomainAccess.Access.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioSolution.Buisness.UserServices
{
    public class UserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }
        public UserViewModel GetUser(string userName, string password)
        {
            var user = _repo.GetUserByUserNameAndPassword(userName, password);
            if (user != null) return null;
            var userResult = new UserViewModel
            {
                UserName = user.Data.UserName,
                Email = user.Data.Email,
                Id = user.Data.Id
            };
            return userResult;
        }
        public UserViewModel AddUser(UserViewModel userViewModel)
        {
            var user = new User(userViewModel.UserName,userViewModel.Password,userViewModel.Email);
            var result = _repo.AddNewUser(user);
            if(!result.IsCompleted)
                return userViewModel;
            return GetUser(userViewModel.UserName,userViewModel.Password);

        }

    }
}

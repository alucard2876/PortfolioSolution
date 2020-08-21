using Microsoft.EntityFrameworkCore;
using PortfolioSolution.Domain.Entitys;
using PortfolioSolution.DomainAccess.Access.Contexts;
using PortfolioSolution.DomainAccess.Access.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioSolution.DomainAccess.Access.Repositorys.Implementetion.EFRepo
{
    public class EFUserRepository : IUserRepository
    {
        private readonly EFContext _context;
        public EFUserRepository(EFContext context)
        {
            _context = context;
        }
        public Result AddNewUser(User user)
        {
            var result = new Result();
            try
            {
                if (user == null)
                    throw new ArgumentNullException(nameof(user));
                _context.Add<User>(user);
                _context.SaveChanges();
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.IsCompleted = true;
            }
            return result;
        }

        public Result<User> AddToDo(Guid userId, ToDoItem item)
        {

            var result = new Result<User>();
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id.Equals(userId));
                if (user == null)
                    throw new ArgumentNullException(nameof(user));
               
                user.AddToDo(item);
                _context.SaveChanges();
                result.Data = user;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.IsCompleted = false;
            }
            return result;
        }

        public Result<User> GetUserByUserNameAndPassword(string userName, string password)
        {
            var result = new Result<User>();
            try
            {
                var data = _context.Users
                    .Include(u=>u.Items)
                    .FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(password));
                if (data == null)
                    throw new ArgumentNullException(nameof(data));
                result.Data = data;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.IsCompleted = false;
            }
            return result;
        }

        public Result<User> UpdateUserName(Guid userId, string userName)
        {
            var result = new Result<User>();
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id.Equals(userId));
                if (user == null)
                    throw new ArgumentNullException(nameof(user));
                user.UpdateUserName(userName);
                _context.Update(user);
                _context.SaveChanges();
                result.Data = user;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.IsCompleted = false;
            }
            return result;
        }

        public Result<User> UpdateUserPassword(Guid userId, string password)
        {
            var result = new Result<User>();
            try
            {
                var user = _context.Users.FirstOrDefault(u=>u.Id.Equals(userId));
                if (user == null)
                    throw new ArgumentNullException(nameof(user));
                user.UpdatePassword(password);
                _context.Update(user);
                _context.SaveChanges();
                result.Data = user;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.IsCompleted = false;
            }
            return result;
        }
    }
}

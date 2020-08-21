using PortfolioSolution.Domain.Entitys;
using System;

namespace PortfolioSolution.DomainAccess.Access.Repositorys.Interfaces
{
    public interface IUserRepository
    {
        Result AddNewUser(User user);
        Result<User> GetUserByUserNameAndPassword(string userName, string password);
        Result<User> UpdateUserName(Guid userId,string userName);
        Result<User> UpdateUserPassword(Guid userId, string password);
        Result<User> AddToDo(Guid userId, ToDoItem item);
        
    }
}

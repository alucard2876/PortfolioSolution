using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioSolution.Domain.Entitys
{
    public class User : EntityBase
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        protected virtual ICollection<ToDoItem> _items { get; private set; }
        public IEnumerable<ToDoItem> Items => _items;

        protected User() { }
        public User(string userName, string password, string email)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            Id = Guid.NewGuid();
            UserName = userName;
            Password = password;
            Email = email;
            _items = new List<ToDoItem>();
            CreatedTime = DateTime.Now;
            LastChangedTime = DateTime.Now;
        }
        public void UpdateUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));
            UserName = userName;
            LastChangedTime = DateTime.Now;
        }
        public void UpdatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));
            Password = password;
            LastChangedTime = DateTime.Now;
        }
        public void AddToDo(ToDoItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioSolution.Domain.Entitys
{
    public class ToDoItem : EntityBase
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Guid UserId { get; private set; }
        public virtual User User { get; private set; }
      
        protected ToDoItem() { }

        public ToDoItem(string title, string description, DateTime endDate, Guid userId, User user)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title)); 
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            StartDate = DateTime.Now.Date;
            EndDate = endDate;
            UserId = userId;
            User = user;
            CreatedTime = DateTime.Now;
            LastChangedTime = DateTime.Now;
        }

        public void UpdateTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));
            Title = title;
            LastChangedTime = DateTime.Now;
        }
        public void UpdateDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));
            Description = description;
            LastChangedTime = DateTime.Now;
        }
        public void UpdateEndDate(DateTime endDate)
        {
            if (endDate == null)
                throw new ArgumentNullException(nameof(endDate));
            EndDate = endDate.Date;
            LastChangedTime = DateTime.Now;
        }
    }
}

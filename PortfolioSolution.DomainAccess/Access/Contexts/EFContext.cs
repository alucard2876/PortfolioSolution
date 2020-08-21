using Microsoft.EntityFrameworkCore;
using PortfolioSolution.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioSolution.DomainAccess.Access.Contexts
{
    public class EFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> Items { get; set; }
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }
    }
}

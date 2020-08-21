using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortfolioSolution.Buisness.UserServices;
using PortfolioSolution.DomainAccess.Access.Contexts;
using PortfolioSolution.DomainAccess.Access.Repositorys.Implementetion.EFRepo;
using PortfolioSolution.DomainAccess.Access.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioSolution.Buisness.Configure
{
    public static class Services
    {
        public static void Configuration(IServiceCollection service,string connection)
        {
            service.AddDbContext<EFContext>(options => options.UseSqlServer(connection));
            service.AddTransient<IUserRepository, EFUserRepository>();
            service.AddTransient<UserService>();
            service.AddTransient<UserService>();
        }
    }
}

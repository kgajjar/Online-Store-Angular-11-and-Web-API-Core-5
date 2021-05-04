﻿using Euromonitor.Api.Helpers;
using Euromonitor.Api.Services;
using Euromonitor.DataAccess.Data;
using Euromonitor.DataAccess.Data.Repository;
using Euromonitor.DataAccess.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euromonitor.Api.Extentions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //AddScoped means service will run for the life of HTTP req.
            services.AddScoped<ITokenService, TokenService>();

            /*We tell AutoMapper where our profiles class is located in our project so that it can inject it as a service
            into our DI container*/
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            //Add Unit Of Work to DI Container
            /*-----------------------------------------------------------------------------*/
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            /*-----------------------------------------------------------------------------*/

            return services;
        }
    }
}

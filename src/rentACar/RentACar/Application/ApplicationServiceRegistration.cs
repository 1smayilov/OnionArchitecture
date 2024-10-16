﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); // Get bütün Assembly lərə bax ordakı bütün command qerylərə bax, onların handlerini tap bir-biri ilə əlaqələndir nə vaxt Send etsəm get handleri işlət
        });

        return services;
    }
}

using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); // Get bütün Assembly lərə bax ordakı bütün command qerylərə bax, onların handlerini tap bir-biri ilə əlaqələndir nə vaxt Send etsəm get handleri işlət
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>)); 
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>)); 
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly()); // AutoMapper

        // BaseBusiness rules tipindəki hər şeyi IOC yə əlavə et 
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(),typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 

        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
      this IServiceCollection services,
      Assembly assembly,
      Type type,
      Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
  )
    {
        // Assembly içərisində mənim subclass(businessRules) olaraq verdiyim kodları tap, IOC yə əlavə et
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList(); 
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);

            else
                addWithLifeCycle(services, type);
        return services;
    }
}

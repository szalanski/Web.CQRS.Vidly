using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Vidly.Application
{
    public static class AddVidlyApplication
    {
        public static IServiceCollection Install(this IServiceCollection serivices)
        {
            serivices.AddAutoMapper(Assembly.GetExecutingAssembly());
            serivices.AddMediatR(Assembly.GetExecutingAssembly());

            return serivices;
        }
    }
}

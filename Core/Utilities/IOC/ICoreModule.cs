using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IOC
{
    // tüm projelerimizde kullanacağımız modulleri burada yazıyoruzz.
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}

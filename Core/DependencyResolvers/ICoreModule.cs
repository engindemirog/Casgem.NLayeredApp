using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{

    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofac
{
    public class ClaimOperation
    {
        string _operationName;
        public ClaimOperation(string operationName)
        {
            //_operationName = operationName;
            //_httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
    }
}

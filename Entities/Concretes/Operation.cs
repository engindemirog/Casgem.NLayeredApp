using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Operation:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } //product.getall
    }

    public class UserOperation:IEntity
    {
        public int Id { get; set; }
        public int OperationId { get; set; }
        public int UserId { get; set; }
    } 
}

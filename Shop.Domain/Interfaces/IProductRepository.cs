using Shop.Domain.Entities;
using Shop.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}

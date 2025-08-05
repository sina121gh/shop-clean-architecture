using Shop.Domain.Entities;
using Shop.Application.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}

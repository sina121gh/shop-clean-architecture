using Shop.Application.Contracts.Persistence.Common;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contracts.Persistence
{
    public interface IUserRepository : IRepository<User>
    {
    }
}

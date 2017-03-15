using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth.Domain.Core;

namespace OAuth.Domain.IRepository
{
    public interface IUserRepo:IBaseRepository<User>
    {
    }
}

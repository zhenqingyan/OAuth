using OAuth.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth.Domain.Core;
using OAuth.Infrastructure.Model;

namespace OAuth.Infrastructure
{
    public class UserRepo :BaseRepository<User,UserModel>,IUserRepo
    {

    }
}

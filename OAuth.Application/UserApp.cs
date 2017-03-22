using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth.Domain.IRepository;
using OAuth.Infrastructure;
using OAuth.Facade;
using AutoMapper;
using OAuth.Domain.Core;

namespace OAuth.Application
{

    public class UserApp
    {
        IUserRepo _userRepo;
        public UserApp(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public bool Insert(UserVm vm)
        {
            var model = Mapper.Map<User>(vm);
            var result = _userRepo.Insert(model);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OAuth.Facade;
using OAuth.Domain.Core;

namespace OAuth.Application
{
    public class UserProfile:Profile
    {
        public UserProfile() {
            CreateMap<UserVm, User>().ReverseMap();
        }
    }
}

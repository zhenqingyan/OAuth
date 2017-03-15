using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OAuth.Domain.Core;
using OAuth.Infrastructure.Model;

namespace OAuth.Infrastructure
{
    public class UserModelProfile:Profile
    {
        public UserModelProfile() {
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}

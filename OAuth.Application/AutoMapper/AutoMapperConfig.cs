using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OAuth.Infrastructure;

namespace OAuth.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(o =>
            {
                o.AddProfile<UserProfile>();
                o.AddProfile<UserModelProfile>();
            });
        }
    }
}

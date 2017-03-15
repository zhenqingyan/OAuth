using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OAuth.Domain;
using OAuth.Domain.Core;
using OAuth.Application;
using OAuth.Infrastructure;
using OAuth.Infrastructure.Model;
using OAuth.Web;
using AutoMapper;
using Autofac;
using OAuth.Domain.IRepository;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mapper.Initialize(o => o.CreateMap<User, UserModel>().ReverseMap());
            var builder = new ContainerBuilder();
            builder.RegisterType<UserRepo>().As<IUserRepo>();

            var container = builder.Build();

            var userRepo=container.Resolve<IUserRepo>();

            var result=userRepo.Insert(new User
            {
                CreateTime = DateTime.Now,
                Creator = "Yan",
                IsDel = 0,
                IsValid = 0,
                LogonName = "Yan",
                Modifier = "Yan",
                RowGuid = Guid.NewGuid().ToString(),
                UpdateTime = DateTime.Now,
                UserName = "Yan",
                UserPassword = "123456"
            });
            Assert.IsTrue(result);
        }
    }
}

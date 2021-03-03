using Autofac;
using PlayBall.GroupManagement.Business.Impl.Services;
using PlayBall.GroupManagement.Business.Models;
using PlayBall.GroupManagement.Business.Services;
using System;
using System.Collections.Generic;

namespace PlayBall.GroupManagement.Web.IoC
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryGroupService>().Named<IGroupService>("groupService").SingleInstance();
            builder.RegisterDecorator<IGroupService>((context, service) => new GroupServiceDecorator(service), "groupService");
        }

        private class GroupServiceDecorator : IGroupService
        {
            private readonly IGroupService _inner;
            public GroupServiceDecorator(IGroupService service)
            {
                _inner = service;
            }

            public Group Add(Group model)
            {
                Console.WriteLine($"####### Hello from {nameof(Add)} #######");
                return _inner.Add(model);
            }

            public IReadOnlyCollection<Group> GetAll()
            {
                Console.WriteLine($"####### Hello from {nameof(GetAll)} #######");
                return _inner.GetAll();
            }

            public Group GetById(long id)
            {
                Console.WriteLine($"####### Hello from {nameof(GetById)} #######");
                return _inner.GetById(id);
            }

            public Group Update(Group model)
            {
                Console.WriteLine($"####### Hello from {nameof(Update)} #######");
                return _inner.Update(model);
            }
        }
    }
}

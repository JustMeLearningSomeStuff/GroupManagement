using System.Collections.Generic;
using PlayBall.GroupManagement.Business.Models;

namespace PlayBall.GroupManagement.Business.Services
{
    public interface IGroupService
    {
        IReadOnlyCollection<Group> GetAll();
        Group GetById(long id);
        Group Update(Group model);
        Group Add(Group model);
    }
}
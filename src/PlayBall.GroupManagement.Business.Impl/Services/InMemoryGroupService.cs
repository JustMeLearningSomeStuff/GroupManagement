namespace PlayBall.GroupManagement.Business.Impl.Services
{
    public class InMemoryGroupService : IGroupService
    {
        private readonly List<Group> _groups = new List<Group>();
        private long _currentId = 0;

        IReadOnlyCollection<Group> GetAll()
        {
            return _groups.AsReadOnly();
        }

        Group GetById(long id)
        {
            return _groups.SingleOrDefault(g => g.Id == id);
        }

        Group Update(Group model)
        {
            var toUpdate = _groups.SingleOrDefault(g => g.Id == id);
            if (toUpdate == null) {
                return null;
            }

            toUpdate.Name = model.Name;
            return toUpdate;
        }

        Group Add(Group model)
        {
            model.Id = ++_currentId;
            _groups.Add(model);

            return model;
        }
    }
}
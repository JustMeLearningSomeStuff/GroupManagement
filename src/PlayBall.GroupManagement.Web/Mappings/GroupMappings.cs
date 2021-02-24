using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PlayBall.GroupManagement.Business.Models;
using PlayBall.GroupManagement.Web.Models;

namespace PlayBall.GroupManagement.Web.Mappings
{
    public static class GroupMappings
    {
        public static GroupViewModel ToViewModel(this Group group) => group == null ? null 
        : new GroupViewModel 
        {
            Id = group.Id,
            Name = group.Name
        };

        public static Group ToServiceModel(this GroupViewModel group) => group == null ? null
        : new Group 
        {
            Id = group.Id,
            Name = group.Name
        };

        public static IReadOnlyCollection<GroupViewModel> ToViewModel(this IReadOnlyCollection<Group> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<GroupViewModel>();
            }

            var groups = new GroupViewModel[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                groups[i] = model.ToViewModel();
                ++i;
            }

            return new ReadOnlyCollection<GroupViewModel>(groups);
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

namespace PandaTime.UserCatalog.Views
{
    public class Group : BaseObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
        public List<Views.Post> Posts { get; set; }

        public Group(Models.Group model, Models.Role role)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            Role = role?.Name;
            CreatedAt = model.CreatedAt;
            LastModified = model.LastModified;

            if (model.Posts != null)
            {
                Posts = new List<Post>();
                foreach (var post in model.Posts)
                {
                    Posts.Add(new Views.Post(post));
                }
            }
        }
    }
}

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

        public Group(Models.Group model, string role)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            Role = role;
            CreatedAt = model.CreatedAt;
            LastModified = model.LastModified;
        }

        public Group(Models.Group model, Models.BaseContext context)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            CreatedAt = model.CreatedAt;
            LastModified = model.LastModified;

            if (context != null)
            {
                var posts = context
                    .Posts
                    .ToList()
                    .Where(x => x.GroupId == model.Id);

                Posts = new List<Post>();
                foreach (Models.Post post in posts)
                {
                    Posts.Add(new Views.Post(post, context));
                }
            }
        }
    }
}

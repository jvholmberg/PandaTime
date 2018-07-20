using System;
using System.Collections.Generic;
using System.Linq;

namespace PandaTime.UserCatalog.Views
{
    public class Post : BaseObject
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        public List<Comment> Comments { get; set; }

        public Post(Models.Post model)
        {
            Id = model.Id;
            Title = model.Title;
            Text = model.Text;
            CreatedAt = model.CreatedAt;
            LastModified = model.LastModified;

            if (model.Author != null)
            {
                Author = new Views.User(model.Author);
            }

            if (model.Comments != null)
            {
                Comments = new List<Comment>();
                foreach (var comment in model.Comments)
                {
                    Comments.Add(new Views.Comment(comment));
                }
            }
        }
    }
}

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

        public Post(Models.Post model, Models.BaseContext context)
        {
            Id = model.Id;
            Title = model.Title;
            Text = model.Text;
            CreatedAt = model.CreatedAt;
            LastModified = model.LastModified;

            if (context != null)
            {
                var author = context
                    .Users
                    .Find(model.AuthorId);

                Author = new Views.User(author);

                var comments = context
                    .Comments
                    .ToList()
                    .Where(x => x.PostId == model.Id);

                Comments = new List<Comment>();
                foreach (Models.Comment comment in comments)
                {
                    Comments.Add(new Views.Comment(comment, context));
                }
            }
        }
    }
}

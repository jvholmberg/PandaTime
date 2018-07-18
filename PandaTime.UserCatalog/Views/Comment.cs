using System;
namespace PandaTime.UserCatalog.Views
{
    public class Comment : BaseObject
    {
        public string Text { get; set; }
        public User Author { get; set; }

        public Comment(Models.Comment model, Models.BaseContext context)
        {
            Id = model.Id;
            Text = model.Text;
            CreatedAt = model.CreatedAt;
            LastModified = model.LastModified;

            if (context != null)
            {
                var author = context
                    .Users
                    .Find(model.AuthorId);

                Author = new Views.User(author);
            }
        }
    }
}

using System;
namespace PandaTime.UserCatalog.Views
{
    public class Comment : BaseObject
    {
        public string Text { get; set; }
        public User Author { get; set; }

        public Comment(Models.Comment model)
        {
            Id = model.Id;
            Text = model.Text;
            CreatedAt = model.CreatedAt;
            LastModified = model.LastModified;

            if (model.Author != null)
            {
                Author = new Views.User(model.Author);
            }
        }
    }
}

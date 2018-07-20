using System;
using System.Linq;
using System.Collections.Generic;

namespace PandaTime.UserCatalog.Views
{
    public class User : BaseObject
    {
        public bool Activated { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Language { get; set; }
        public List<Views.Group> Groups { get; set; }

        public User()
        {

        }

        public User(Models.User model)
        {
            Id = model.Id;
            Activated = model.Activated;
            Email = model.Email;
            FirstName = model.FirstName;
            LastName = model.LastName;
            CreatedAt = model.CreatedAt;
            LastModified = model.LastModified;

            if (model.Language != null)
            {
                Language = model.Language.Code;
            }

            if (model.Memberships != null)
            {
                Groups = new List<Group>();
                foreach (var membership in model.Memberships)
                {
                    if (membership.Group.Personal)
                    {
                        Role = membership.Role.Name;
                    }
                    else {
                        Groups.Add(new Views.Group(membership.Group, membership.Role));
                    }
                }
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace PandaTime.UserCatalog.Views
{
    public class User : BaseObject
    {
        public bool Activated { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Language { get; set; }
        public List<Views.Group> Groups { get; set; }

        public User(Models.User model, Models.BaseContext context)
        {
            Id = model.Id;
            Activated = model.Activated;
            Email = model.Email;
            FirstName = model.FirstName;
            LastName = model.LastName;
            CreatedAt = model.CreatedAt;
            LastModified = model.LastModified;

            // If context is provided explore relationships
            if (context != null)
            {
                // Get Language
                var language = context.Languages.Find(model.LanguageId);
                Language = language.Code;

                // Get Memberships
                var memberships = context
                    .Memberships
                    .ToList()
                    .Where(x => x.UserId == model.Id);

                var groups = context.Groups.ToDictionary(x => x.Id);
                var roles = context.Roles.ToDictionary(x => x.Id);

                Groups = new List<Group>();
                foreach(Models.Membership membership in memberships)
                {
                    var group = groups[membership.GroupId];
                    var role = roles[membership.RoleId];

                    if (group.Personal)
                    {
                        // Get Role for user
                        Role = role.Name;
                    }
                    else
                    {
                        Groups.Add(new Views.Group(group, role.Name));
                    }
                }
            }
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
        }
    }
}

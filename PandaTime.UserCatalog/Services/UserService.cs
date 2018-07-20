using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PandaTime.UserCatalog.Services
{
    public class UserService
    {
        private readonly Models.BaseContext _Context;

        public UserService(Models.BaseContext context)
        {
            _Context = context;
        }

        public async Task<Views.User> Create(Views.User view)
        {
            try
            {
                var language = await _Context.Languages
                    .SingleAsync(lng => lng.Code == view.Language);

                var role = await _Context.Roles
                    .SingleAsync(rle => rle.Name == "Moderator");
                
                var group = _Context.Groups.Add(new Models.Group
                {
                    Personal = true,
                    CreatedAt = DateTime.UtcNow
                });


                var user = _Context.Users.Add(new Models.User
                {
                    Activated = false,
                    Email = view.Email,
                    Password = view.Password,
                    FirstName = view.FirstName,
                    LastName = view.LastName,
                    LanguageId = language.Id,
                    CreatedAt = DateTime.UtcNow
                });

                await _Context.SaveChangesAsync();

                var dbGroup = group.GetDatabaseValues().ToObject() as Models.Group;
                var dbUser = user.GetDatabaseValues().ToObject() as Models.User;

                _Context.Memberships.Add(new Models.Membership
                {
                    GroupId = dbGroup.Id,
                    UserId = dbUser.Id,
                    RoleId = role.Id,
                    CreatedAt = DateTime.UtcNow
                });

                await _Context.SaveChangesAsync();

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Views.User>> GetAll()
        {
            try
            {
                var users = await _Context.Users.ToListAsync();
                return users.Select(usr => new Views.User(usr));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Views.User> GetById(int id) {
            try
            {
                var user = await _Context.Users
                .Include(usr => usr.Language)
                .Include(usr => usr.Memberships)
                    .ThenInclude(mem => mem.Group)
                        .ThenInclude(grp => grp.Memberships)
                            .ThenInclude(mem => mem.Role)
                .SingleAsync(usr => usr.Id == id);
                
                return new Views.User(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(int id)
        {
            return _Context.Users.Any(usr => usr.Id == id);
        }
    }
}

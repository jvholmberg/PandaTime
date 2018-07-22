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
                // Get generic data language/role for user
                var language = await _Context.Languages
                    .SingleAsync(lng => lng.Code == view.Language);

                var role = await _Context.Roles
                    .SingleAsync(rle => rle.Name == "Moderator");

                // Create explicit data for user
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

                _Context.Memberships.Add(new Models.Membership
                {
                    GroupId = group.Entity.Id,
                    UserId = user.Entity.Id,
                    RoleId = role.Id,
                    CreatedAt = DateTime.UtcNow
                });

                // Save changes to database
                await _Context.SaveChangesAsync();

                // Return created user from database
                return await GetById(user.Entity.Id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Views.User> Activate(int id)
        {
            try
            {
                // Update user
                var user = await _Context.Users.FindAsync(id);
                _Context.Entry(user).Entity.Activated = true;

                // Save changes to database
                await _Context.SaveChangesAsync();

                // Return updated user from database
                return await GetById(user.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Views.User> UpdateDetails(Views.User view)
        {
            try
            {
                // Get requested language from database
                var language = await _Context.Languages
                    .SingleAsync(lng => lng.Code == view.Language);

                // Get user from database
                var user = await _Context.Users.FindAsync(view.Id);

                // Update entity
                _Context.Entry(user).Entity.Email = view.Email;
                _Context.Entry(user).Entity.FirstName = view.FirstName;
                _Context.Entry(user).Entity.LastName = view.LastName;
                _Context.Entry(user).Entity.LanguageId = language.Id;

                // Save changes to database
                await _Context.SaveChangesAsync();

                // Return updated user from database
                return await GetById(view.Id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Views.User> UpdatePassword()
        {
            throw NotImplementedException();
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var user = await _Context.Users
                .Include(usr => usr.Memberships)
                    .ThenInclude(mem => mem.Role)
                .SingleAsync(usr => usr.Id == id);
                
                var personalMemberships = user.Memberships.Where(mem => mem.Group.Personal);
                personalMemberships.Select(mem => _Context.Groups.Remove(mem.Group));
                personalMemberships.Select(mem => _Context.Memberships.Remove(mem));
                _Context.Users.Remove(user);

                await _Context.SaveChangesAsync();

                return 1;
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

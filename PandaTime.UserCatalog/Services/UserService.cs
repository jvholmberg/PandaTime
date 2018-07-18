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

        public IEnumerable<Views.User> GetAll()
        {
            try
            {
                var users = _Context.Users.ToList();
                return users.Select(x => new Views.User(x, _Context));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Views.User GetById(int id)
        {

            try
            {
                var user = _Context.Users.Find(id);
                return new Views.User(user, _Context);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

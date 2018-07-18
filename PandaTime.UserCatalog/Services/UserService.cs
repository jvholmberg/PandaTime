using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaTime.UserCatalog.Models;

namespace PandaTime.UserCatalog.Services
{
    public class RoleService
    {
        private readonly BaseContext _Context;

        public RoleService(BaseContext context)
        {
            _Context = context;
        }

        public async Task<Role> GetSingle(string name)
        {
            try
            {
                var role = await _Context.Roles.SingleOrDefaultAsync(x => x.Name == name);
                return role;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Role> GetAll()
        {
            try
            {
                var roles = _Context.Roles;
                return roles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

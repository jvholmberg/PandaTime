using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PandaTime.UserCatalog.Models;
using PandaTime.UserCatalog.Services;

namespace PandaTime.UserCatalog.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly BaseContext _Context;
        private readonly UserService _UserService;

        public UserController(BaseContext context)
        {
            _Context = context;
            _UserService = new UserService(_Context);
        }

        // GET api/user
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _UserService.GetAll();

            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_UserService.Exists(id))
            {
                return NotFound();
            }

            var user = await _UserService.GetById(id);

            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Views.User view)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _UserService.Create(view);

            return CreatedAtAction("Post", user);

        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            _Context.Entry(user).State = EntityState.Modified;

            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_UserService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _Context.Users.SingleOrDefaultAsync(usr => usr.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _Context.Users.Remove(user);
            await _Context.SaveChangesAsync();

            return Ok(user);
        }
    }
}

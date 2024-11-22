using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using UserRegister.Data;
using UserRegister.Models;
using UserRegister.Services;

namespace UserRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserServices _services;

        public UsersController(UserServices service)
        {
            _services = service;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _services.getUserAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _services.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserCreateDTO user)
        {

            var existingUser = await _services.GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                return BadRequest(new { mensaje = "El correo ya registrado" });
            }
            var data = await _services.CreateUser(user);
            return CreatedAtAction("GetUser", new { id = data.Id }, user);
        }

    
    }
}

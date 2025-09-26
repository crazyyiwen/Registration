using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registration.data;
using Registration.models;

namespace Registration.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class UsersController: ControllerBase
    {
        private readonly AlarmUserDbContext _context;

        public UsersController ( AlarmUserDbContext context )
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet("getAll")]
        public async Task<IActionResult> GetUsers ( )
        {
            var users = await _context.Users.ToListAsync ( );
            return Ok (users);
        }

        // GET: api/users/{id}
        [HttpGet ("get/{id}")]
        public async Task<IActionResult> GetUserById ( int id )
        {
            var user = await _context.Users.FindAsync (id);
            if (user == null)
                return NotFound (new { message = $"User with Id {id} not found." });

            return Ok (user);
        }

        // POST: api/users/AddUser
        [HttpPost ("AddUser")]
        public async Task<IActionResult> AddUser ( [FromBody] User user )
        {
            if (user == null)
                return BadRequest (new { message = "Invalid user data" });

            await _context.Users.AddAsync (user);
            await _context.SaveChangesAsync ( );

            return Ok (new { message = "User added successfully" , user });
        }

        // PUT: api/users/UpdateUser/{id}
        [HttpPut ("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser ( int id , [FromBody] User updatedUser )
        {
            var user = await _context.Users.FindAsync (id);
            if (user == null)
                return NotFound (new { message = $"User with Id {id} not found." });

            user.name = updatedUser.name;
            user.password = updatedUser.password;
            user.start_time = updatedUser.start_time;
            user.end_time = updatedUser.end_time;
            user.isadminuser = updatedUser.isadminuser;
            user.permissions = updatedUser.permissions;

            await _context.SaveChangesAsync ( );
            return Ok (new { message = "User updated successfully" , user });
        }

        // DELETE: api/users/DeleteUser/{id}
        [HttpDelete ("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser ( int id )
        {
            var user = await _context.Users.FindAsync (id);
            if (user == null)
                return NotFound (new { message = $"User with Id {id} not found." });

            _context.Users.Remove (user);
            await _context.SaveChangesAsync ( );

            return Ok (new { message = "User deleted successfully" });
        }
    }
}

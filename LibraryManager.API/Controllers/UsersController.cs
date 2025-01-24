using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LibraryManagerDbContext _context;
        public UsersController(LibraryManagerDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users
                .FirstOrDefault(u => !u.IsDeleted && u.Id == id);
            return Ok(user);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _context.Users
                .Where(u => !u.IsDeleted)
                .ToList();

            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var user = model.ToEntity();

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = user.Id},model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateUserInputModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            user.Update(model.Name, model.Email);

            _context.Users.Update(user);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            user.SetAsDeleted();

            _context.Users.Update(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

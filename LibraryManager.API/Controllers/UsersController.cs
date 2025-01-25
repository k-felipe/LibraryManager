using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using LibraryManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManager.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.GetById(id);

            var model = UserViewModel.FromEntity(user);
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var users = await _repository.GetAll();
            var model = users.Select(UserViewModel.FromEntity).ToList();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateUserInputModel model)
        {
            var user = model.ToEntity();

            await _repository.Insert(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, UpdateUserInputModel model)
        {
            var user = await _repository.GetById(id);

            user.Update(model.Name, model.Email);

            await _repository.Update(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var user = await _repository.GetById(id);

            user.SetAsDeleted();

            await _repository.Update(user);

            return NoContent();
        }
    }
}

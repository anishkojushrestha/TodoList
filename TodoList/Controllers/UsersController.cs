using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Dto;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var data = _context.users.Where(x => x.UserName == username && x.Password == password).Select(x => new Users
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                FirstName = x.FirstName,
                lastName = x.lastName,
                Role = x.Role,

            }).FirstOrDefault();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UsersDto dto)
        {
            if(dto.NewPassword == dto.ConfirmPassword)
            {
                await _context.users.AddAsync(new Users
                {
                    UserName = dto.UserName,
                    FirstName = dto.FirstName,
                    lastName = dto.lastName,
                    Email = dto.Email,
                    Role = dto.Role,
                    Password = dto.NewPassword,
                });
                await _context.SaveChangesAsync();
            }

              
            
            return Ok();
        }
    }
}

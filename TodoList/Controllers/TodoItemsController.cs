using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TodoList.Data;
using TodoList.Dto;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TodoItemsController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        [HttpPost]
        public async Task<IActionResult> AddTodoItems(TodoItemsDto dto)
        {
            await _context.todoItems.AddAsync(new TodoItems
            {
                Description= dto.Description,
                Title= dto.Title,
                IsCompleted = dto.IsCompleted,
            });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetTodoItems() {
            IEnumerable<TodoItems> result = _context.todoItems;
            return Ok(result); 
        }

        
        //public async Task<IActionResult> UpdateTodoItems(int id)
        //{
        //    var result = await _context.todoItems.FirstOrDefaultAsync(x => x.Id == id);
        //    return Ok(result);
        //}

        [HttpPut]
        public async Task<IActionResult> UpdateTodoItems(int id, TodoItemsDto dto)
        {
            var result = await _context.todoItems.FirstOrDefaultAsync(x=>x.Id == id);
            if (result != null)
            {
                result.IsCompleted = dto.IsCompleted;
                result.Description = dto.Description;   
                result.Title = dto.Title;
                await _context.SaveChangesAsync();

            }
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.todoItems.FirstOrDefaultAsync(x=>x.Id == id);
            if (result != null)
            {
                 _context.Remove(result);
                await _context.SaveChangesAsync();  
            }
            return Ok();
        }
    }
}

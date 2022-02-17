using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoonboard_api.Context;
using todoonboard_api.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using todoonboard_api.infoModels;

namespace todoonboard_api.Controllers{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase{
        
        private readonly DBContext _context;
        public TodoController(DBContext context)
        {
            _context = context;
        }

        [HttpGet("uncompletedTasks")]
        public IEnumerable<Todo> GetTasksNotCompleted(){
            var todos = _context.Todos.Where(item => !item.done).ToList();
            return todos;
        }
        [HttpPost("{bid}")]
        public IActionResult AddTodo(int bid, TodoRequest newTodo){
            newTodo.bid = bid;
            Todo todoToBeAdded = new Todo(newTodo);
            _context.Todos.Add(todoToBeAdded);
            _context.SaveChanges();
            return Ok(todoToBeAdded);
        }
        [HttpPost("insertMany")]
        public IActionResult AddTodoMultiple(TodoRequest[] newTodo){
            List<Todo> todoToBeAdded = new List<Todo>();
            foreach(var item in newTodo)
            {
            todoToBeAdded.Add(new Todo(item));
            }
            _context.Todos.AddRange(todoToBeAdded);
            _context.SaveChanges();
            return Ok(todoToBeAdded);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ChangeTodo(int id, TodoRequest req){
            if(id != req.id)
            return BadRequest();

            var row = await _context.Todos.FirstOrDefaultAsync(item => item.id == id);
            if(row != null){
                row.title = req.title;
                row.bid=req.bid;
                row.done = req.done;
                row.updatedAt = DateTime.Now;
                req.createdAt=row.createdAt;
                req.updatedAt=row.updatedAt;
                _context.SaveChanges();
                return Ok(req);
            }
            else{
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            var todo = _context.Todos.Find(id);

            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
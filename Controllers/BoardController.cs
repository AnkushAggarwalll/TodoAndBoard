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
    public class BoardController : ControllerBase{
        private readonly DBContext _context;
        public BoardController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boards>>> GetBoards(){
            return await _context.Boards.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Boards>> InsertBoard(Boards board)
        {
            _context.Boards.Add(board);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBoards), new { id = board.id }, board);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            var board = await _context.Boards.FindAsync(id);

            if (board == null)
            {
                return NotFound();
            }

            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> ChangeBoard(int id, BoardChangeRequest req){
            if(id != req.id)
            return BadRequest();

            var row = await _context.Boards.FirstOrDefaultAsync(item => item.id == id);
            if(row != null){
                row.BoardName = req.newBoardName;
                _context.SaveChanges();
                return Ok(req);
            }
            else{
                return NotFound();
            }
        }
        [HttpGet("BoardTodos/{id}")]
        public IEnumerable<Todo> GetBoardTodo(int id){
            var todos = _context.Todos.Where(item => item.bid == id).ToList();
            return todos;
        }
    }
}
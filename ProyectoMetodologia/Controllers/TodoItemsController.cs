using Microsoft.AspNetCore.Mvc;
using ProyectoMetodologia.Models;
using ProyectoMetodologia.Services;

namespace ProyectoMetodologia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll() => TodoService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(long id)
        {
            var item = TodoService.Get(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public ActionResult<TodoItem> Post(TodoItem item)
        {
            var created = TodoService.Add(item);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, TodoItem item)
        {
            if (!TodoService.Update(id, item)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (!TodoService.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}

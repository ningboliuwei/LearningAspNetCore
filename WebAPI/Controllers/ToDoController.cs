using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ToDoController : Controller
    {
        private readonly TodoContext _context;

        public ToDoController(TodoContext todoContext)
        {
            _context = todoContext;
            if (!_context.TodoItems.Any())
            {
                _context.TodoItems.Add(new TodoItem() {Name = "张三"});
                _context.SaveChanges();
            }
        }
        // GET: api/ToDo
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _context.TodoItems.ToList();
        }

        // GET: api/ToDo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/ToDo
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/ToDo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

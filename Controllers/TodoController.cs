using DotNetCoreExample.Models;
using DotNetCoreExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly DbMockUpService db;

        public TodoController(DbMockUpService db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetTodoList()
        {
            try
            {
                ResponseModel res = new ResponseModel(true, "Success", db.Todos);
                return Ok(res);
            }
            catch (Exception ex)
            {
                ResponseModel res = new ResponseModel(false, ex.Message);
                return BadRequest(res);
            }
        }

        [HttpGet]
        public IActionResult GetTodoById(int id)
        {
            try
            {
                var todo = db.Todos.FirstOrDefault(it => it.Id == id);
                if (todo == null) throw new Exception("Not found.");

                ResponseModel res = new ResponseModel(true, "Success", todo);
                return Ok(res);
            }
            catch (Exception ex)
            {
                ResponseModel res = new ResponseModel(false, ex.Message);
                return BadRequest(res);
            }

        }

        [HttpPost]
        public IActionResult AddTodo([FromBody] TodoModel todo)
        {
            try
            {
                var count = db.Todos.Count;
                todo.Id = count + 1;
                db.Todos.Add(todo);

                ResponseModel res = new ResponseModel(true, "Success", todo);

                return Ok(res);
            }
            catch (Exception ex)
            {
                ResponseModel res = new ResponseModel(false, ex.Message);
                return BadRequest(res);
            }
        }

        [HttpPut]
        public IActionResult UpdateTodo([FromBody] TodoModel todo)
        {
            try
            {

                var todoUpdate = db.Todos.FirstOrDefault(it => it.Id == todo.Id);
                if (todoUpdate == null) throw new Exception("Not found.");

                todoUpdate.Title = todo.Title;
                todoUpdate.Completed = todo.Completed;
                ResponseModel res = new ResponseModel(true, "Success", todo);

                return Ok(res);
            }
            catch (Exception ex)
            {
                ResponseModel res = new ResponseModel(false, ex.Message);
                return BadRequest(res);
            }

        }

        [HttpPut]
        public IActionResult UpdateTodoStatus([FromBody] TodoModel todo)
        {
            try
            {
                var todoUpdate = db.Todos.FirstOrDefault(it => it.Id == todo.Id);
                if (todoUpdate == null) throw new Exception("Not found.");

                todoUpdate.Completed = todo.Completed;
                ResponseModel res = new ResponseModel(true, "Success", todoUpdate);

                return Ok(res);
            }
            catch (Exception ex)
            {
                ResponseModel res = new ResponseModel(false, ex.Message);
                return BadRequest(res);
            }
        }

        [HttpDelete]
        public IActionResult DeleteTodoById(int id)
        {
            try
            {
                var todoDelete = db.Todos.FirstOrDefault(it => it.Id == id);
                if (todoDelete == null) throw new Exception("Not found.");

                db.Todos.Remove(todoDelete);
                ResponseModel res = new ResponseModel(true, "Success", todoDelete);

                return Ok(res);
            }
            catch (Exception ex)
            {
                ResponseModel res = new ResponseModel(false, ex.Message);
                return BadRequest(res);
            }
        }
    }
}

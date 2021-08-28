using DotNetCoreExample.Models;
using DotNetCoreExample.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DbMockUpService db;
        private readonly IWebHostEnvironment hostEnvironment;

        public BookController(DbMockUpService db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]

        public IActionResult GetBookList()
        {
            try
            {
                var books = db.Books;
                ResponseModel res = new ResponseModel(true, "Success", books);
                return Ok(res);
            }
            catch (Exception ex)
            {
                ResponseModel res = new ResponseModel(false, ex.Message);
                return BadRequest(res);

            }
        }

        [HttpGet]
        public IActionResult GetBookById(int id)
        {
            try
            {
                var book = db.Books.FirstOrDefault(it => it.Id == id);
                if (book == null) throw new Exception("Not found.");

                ResponseModel res = new ResponseModel(true, "Success", book);
                return Ok(res);
            }
            catch (Exception ex)
            {
                ResponseModel res = new ResponseModel(false, ex.Message);
                return BadRequest(res);
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookModel book)
        {
            try
            {
                var lastBook = db.Books.LastOrDefault();
                book.Id = lastBook.Id + 1; 

                db.Books.Add(book);
                ResponseModel res = new ResponseModel(true, "Success", book);
                return Ok(res);
            }
            catch (Exception ex)
            {
                ResponseModel res = new ResponseModel(false, ex.Message);
                return BadRequest(res);
            }
        }

        [HttpPut]
        public IActionResult UpdateBook([FromBody] BookModel book)
        {
            try
            {
                var bookUpdate = db.Books.FirstOrDefault(it => it.Id == book.Id);
                if (bookUpdate == null) throw new Exception("Not found.");

                bookUpdate.Name = book.Name;
                bookUpdate.Description = book.Description;
                bookUpdate.Price = book.Price;
                bookUpdate.Discount = book.Discount;
                bookUpdate.InStock = book.InStock;
                bookUpdate.SaleCount = book.SaleCount;
                bookUpdate.Count = book.Count;
                bookUpdate.ImageUrl = book.ImageUrl;
                bookUpdate.IsActive = book.IsActive;

                ResponseModel res = new ResponseModel(true, "Success", bookUpdate);
                return Ok(res);
            }
            catch (Exception ex)
            {
                ResponseModel res = new ResponseModel(false, ex.Message);
                return BadRequest(res);
            }
        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var bookDelete = db.Books.FirstOrDefault(it => it.Id == id);
                if (bookDelete == null) throw new Exception("Not found.");

                RemoveImage(bookDelete);
                db.Books.Remove(bookDelete);

                ResponseModel res = new ResponseModel(true, "Success", bookDelete);
                return Ok(res);
            }
            catch (Exception ex)
            {
                ResponseModel res = new ResponseModel(false, ex.Message);
                return BadRequest(res);
            }
        }


        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] FileUploadModel req)
        {
            try
            {
                string webRootPath = hostEnvironment.WebRootPath;
                string fileName = req.File.FileName;
                string subPath = @"img";

                string currentUrl = @"https://" +  HttpContext.Request.Host.Value;

                using (Stream sm =  System.IO.File.Create(webRootPath + @"\" + subPath + @"\" + fileName))
                {
                    await req.File.CopyToAsync(sm);
                }

                ResponseModel res = new ResponseModel(true, "Success", new { ImgUrl = currentUrl + "/" + subPath + "/" + fileName }) ;

                return Ok(res);
            }
            catch (Exception ex)
            {
                ResponseModel res = new ResponseModel(false, ex.Message);
                return BadRequest(res);
            }
        }

        private bool RemoveImage(BookModel book)
        {
            var paths = book.ImageUrl.Split('/');
            string webRootPath = hostEnvironment.WebRootPath;
            string subPath = @"\\img\\";

            if (System.IO.File.Exists(webRootPath + subPath + paths[paths.Length - 1]))
            {
                System.IO.File.Delete(webRootPath + subPath + paths[paths.Length - 1]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

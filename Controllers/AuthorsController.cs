using System.Collections.Generic;
using System.Linq;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers{
    
     [Route("api/v1/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly LibraryDbContext _context;
        
        public AuthorsController(LibraryDbContext context){
            _context = context;
        }
        
        [HttpGet]
        public List<Author> Get(){
         return  _context.Authors.ToList();
         
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
          var author= this._context.Authors.SingleOrDefault(ct=> ct.Id_Author ==id);
          if(author != null){
              return Ok(author);
          }else{
              return NotFound();
          }

        }
        [HttpPost]
        public IActionResult PostAuthors([FromBody] Author author)
        {
            if(!this.ModelState.IsValid){
                return BadRequest();
            }
            this._context.Authors.Add(author);
            this._context.SaveChanges();
            return Created($"authors/{author.Id_Author}", author);
        }

        [HttpPut("{id}")]
        public IActionResult PutAuthors(int id, [FromBody] Author author){
        
            var target = _context.Authors.FirstOrDefault(ct=> ct.Id_Author == id);
                if(target == null)
                {
                    return NotFound();
                }
                else
                {
                target.Id_Author = author.Id_Author;
                target.Name = author.Name;
                target.Last_Name = author.Last_Name;
                target.Email = author.Email;

                _context.Authors.Update(target);
                _context.SaveChanges();
                return new NoContentResult();
                }
               
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthors(int id){
           var target = _context.Authors.FirstOrDefault(ct=> ct.Id_Author == id);
            if(!this.ModelState.IsValid){
                return BadRequest();
            }
            else{
                _context.Authors.Remove(target);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}

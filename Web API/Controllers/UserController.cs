using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MyLibraryContract.Users;


namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogController : ControllerBase
    {
       
        [HttpGet("{Login}")]
        public async Task<ActionResult<UserAuthorization>> Get(string Login)
        {
            //UserAuthorization user = await db.UsersLog.FirstOrDefaultAsync(x => x.Login == Login);
           // if (user == null)
             //   return new ObjectResult(false);
            return new ObjectResult(true);
        } 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAuthorization>>> GetAll()
        {
            //return await db.UsersLog.ToListAsync();
            return null;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAuthorization>> Get(int id)
        {
            // UserAuthorization user = await db.UsersLog.FirstOrDefaultAsync(x => x.Id == id);
            // if (user == null)
            //    return NotFound();
            //return new ObjectResult(user);
            return null;
        }
        [HttpPost]
        public async Task<ActionResult<UserAuthorization>> Post(UserAuthorization user)
        {
            //if (user == null)
            //{
            //    return BadRequest();
            //}

            //db.UsersLog.Add(user);
            //await db.SaveChangesAsync();
            return Ok(user);
        }

    }
}

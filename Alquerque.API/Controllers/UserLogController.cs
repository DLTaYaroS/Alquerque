//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using Alquerque.User.Authorization;
//using System.Threading.Tasks;

//using AlquerqueContract.Users;


//namespace Alquerque.API.Controllers
//{
//    [Route("api/user")]
//    [ApiController]
//    public class UserLogController : ControllerBase
//    {
       
//        //[HttpGet("{Login}")]
//        //public async Task<ActionResult<UserAuthorization>> Get(string Login)
//        //{
//        //    //UserAuthorization user = await db.UsersLog.FirstOrDefaultAsync(x => x.Login == Login);
//        //   // if (user == null)
//        //     //   return new ObjectResult(false);
//        //    return new ObjectResult(true);
//        //} 
//        //[HttpGet]
//        //public async Task<ActionResult<IEnumerable<UserAuthorization>>> GetAll()
//        //{
//        //    //return await db.UsersLog.ToListAsync();
//        //    return null;
//        //}
//        //[HttpGet("{id}")]
//        //public async Task<ActionResult<UserAuthorization>> Get(int id)
//        //{
//        //    // UserAuthorization user = await db.UsersLog.FirstOrDefaultAsync(x => x.Id == id);
//        //    // if (user == null)
//        //    //    return NotFound();
//        //    //return new ObjectResult(user);
//        //    return null;
//        //}
//        [HttpPost("Registration")]
//        public async Task<ActionResult<LoginModel>> Registration(LoginModel user)
//        {
//            if (user == null)
//            {
//                return BadRequest();
//            }
            
//            Authorization auth = new Authorization();
//            try
//            {
//                await auth.NewUser(user);
//                return Ok("Succesfully registration");
//            }
//            catch(Exception ex)
//            {
//                return BadRequest(ex);
//            }
            
//        }
//        [HttpPost("Authorization")]
//        public async Task<ActionResult<string>> Authorization(LoginModel user)
//        {
//            if (user == null)
//            {
//                return BadRequest();
//            }

//            Authorization auth = new Authorization();
//            try
//            {
//                if (auth.LogInAccount(user))
//                {
//                    return Ok("Succesfully authorization");
//                }
//                return Ok("UnSuccesfully authorization");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex);
//            }

//        }

//    }
//}

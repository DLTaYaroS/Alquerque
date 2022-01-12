using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alquerque.User.Authorization;
using AlquerqueContract.Users;

namespace Alquerque.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AccountController : Controller
    {
        //private readonly UserManager<LoginModel> _userManager;
        //private readonly SignInManager<LoginModel> _signInManager;

        //public AccountController(UserManager<LoginModel> userManager, SignInManager<LoginModel> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginModel>> Get(int id)
        {
            DataUser db = new DataUser();
            LoginModel user = db.Get(id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
            
        }
        [HttpGet]
        public ActionResult<IEnumerable<LoginModel>> Get()
        {
            DataUser db = new DataUser();
            return db.GetAll().ToList();
        }
        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Register(LoginModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        LoginModel user = new LoginModel { Login = model.Login };
        //        // add user
        //        var result = await _userManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            // create cookie
        //            await _signInManager.SignInAsync(user, false);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //    }
        //    return View(model);
        //}
        [HttpPost("Registration")]
        public async Task<ActionResult<LoginModel>> Registration(LoginModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            Authorization auth = new Authorization();
            try
            {
                await auth.NewUser(user);
                return Ok("Succesfully registration");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost("Authorization")]
        public async Task<ActionResult<string>> Authorization(LoginModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            Authorization auth = new Authorization();
            try
            {
                if (auth.LogInAccount(user))
                {
                    return Ok("Succesfully authorization");
                }
                return Ok("UnSuccesfully authorization");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}


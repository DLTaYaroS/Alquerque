using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alquerque.User.Authorization;
using AlquerqueContract.Users;
using AlquerqueDataAccess.Entitys.Person;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Alquerque.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserLogController : Controller
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            DataUser db = new DataUser();
            Person user = db.Get(id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);

        }
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            DataUser db = new DataUser();
            return db.GetAll().ToList();
        }

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
                if (auth.LogInAccount(user) != null)
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            Authorization auth = new Authorization();
            //check role
            await auth.DeleteUser(id);
            return Ok("Delete");
        }
        [HttpPost("/token")]
        public IActionResult Token(LoginModel model)
        {
            var identity = GetIdentity(model);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        private ClaimsIdentity GetIdentity(LoginModel model)
        {
            Authorization auth = new Authorization();

            Person person = auth.LogInAccount(model);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.RoleId.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}


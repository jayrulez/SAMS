using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Entities;
using WebApi.Infrastructure.DataStores;
using WebApi.Infrastructure.Managers;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : BaseController
    {
        internal UserManager _manager;

        public UserController()
        {
            _manager = new UserManager(new UserStore());
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_manager.Users.ToList().Select(u => u.ToPresenter()));
        }

        [Route("create")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(CreateUserModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                LocationId = model.LocationId,
                UserName = model.UserName
            };

            var result = await _manager.CreateAsync(user, model.Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }

                return BadRequest(ModelState);
            }

            return Ok(user.ToPresenter());
        }
    }
}

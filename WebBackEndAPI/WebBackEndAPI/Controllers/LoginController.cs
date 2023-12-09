using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebBackEndAPI.Models;
namespace WebBackEndAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LoginController : ApiController
    {

        private ProjectEntities3 db = new ProjectEntities3();


        [HttpPost]
        public IHttpActionResult GetByEmail([FromBody]user_db user)
        {

            var UserByEmail = from a in db.user_db
                              where a.email == user.email && a.pass_w == user.pass_w
                              select a;
            if (UserByEmail != null)
            {
                return Ok(UserByEmail);
            }
            else
            {
                return NotFound();
            }

        }


       
    }
}

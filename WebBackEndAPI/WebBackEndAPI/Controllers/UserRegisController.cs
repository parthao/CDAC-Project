using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebBackEndAPI.Models;

namespace WebBackEndAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UserRegisController : ApiController
    {
        private ProjectEntities3 db = new ProjectEntities3();

        //[HttpPost]
        //public IHttpActionResult GetByEmail([FromBody]user_db user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var UserByEmail = from a in db.user_db
        //                      where a.email == user.email && a.pass_w == user.pass_w
        //                      select a;
        //    if (UserByEmail != null)
        //    {
        //        return Ok(UserByEmail);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

       



        // POST: api/UserRegis
        [ResponseType(typeof(user_db))]
        public IHttpActionResult Postuser_db(user_db user_db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.user_db.Add(user_db);

            try
            {
                db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = user_db.usr_id }, user_db);
            }
            catch (DbUpdateException ex)
            {
                if(ex.InnerException.InnerException.Message.Contains("UNIQUE KEY"))
                {
                    return Json("ER_DUP_ENTRY");
                }
                else
                {
                    throw;
                }
            }
           

           
        }

    
        
    }
}
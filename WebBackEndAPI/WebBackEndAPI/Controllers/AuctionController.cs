using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    public class AuctionController : ApiController
    {
        private ProjectEntities3 db = new ProjectEntities3();

        // GET: api/Auction
        public IQueryable<aution_table> Getaution_table()
        {
            return db.aution_table;
        }

        // GET: api/Auction/5
        [ResponseType(typeof(aution_table))]
        public IHttpActionResult Getaution_table(int id)
        {
            aution_table aution_table = db.aution_table.Find(id);
            if (aution_table == null)
            {
                return NotFound();
            }

            return Ok(aution_table);
        }

        // PUT: api/Auction/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaution_table(int id, aution_table aution_table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aution_table.auc_id)
            {
                return BadRequest();
            }

            db.Entry(aution_table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aution_tableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Auction
        [ResponseType(typeof(aution_table))]
        public IHttpActionResult Postaution_table(aution_table aution_table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.aution_table.Add(aution_table);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aution_table.auc_id }, aution_table);
        }

        // DELETE: api/Auction/5
        [ResponseType(typeof(aution_table))]
        public IHttpActionResult Deleteaution_table(int id)
        {
            aution_table aution_table = db.aution_table.Find(id);
            if (aution_table == null)
            {
                return NotFound();
            }

            db.aution_table.Remove(aution_table);
            db.SaveChanges();

            return Ok(aution_table);
        }


        [ResponseType(typeof(Object))]
        [Route("api/GetProducAuctionByID/{id}")]
        [HttpGet]
        public IQueryable<Object> GetProductAuctionByID(int ID)
        {
            var auction = from a in db.aution_table
                          where a.product_p_id == ID
                          select a;

            return auction;

        }

        [ResponseType(typeof(Object))]
        [Route("api/GetProductOnJoinFromAuction")]
        [HttpGet]
        public IQueryable<Object> GetProductOnAuction()
        {
            var query = from a in db.aution_table
                        join p in db.products on a.product_p_id equals p.p_id into joined
                        from j in joined.DefaultIfEmpty()
                        select new
                        {
                            a.auc_id,j.p_id,j.p_imgloc,j.p_name,j.p_descp,j.p_category
                        };

            return query;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool aution_tableExists(int id)
        {
            return db.aution_table.Count(e => e.auc_id == id) > 0;
        }
    }
}
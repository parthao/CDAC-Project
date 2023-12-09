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
    public class BidController : ApiController
    {
        private ProjectEntities3 db = new ProjectEntities3();

        
        // GET: api/Bid
        public IQueryable<bid_table> Getbid_table()
        {
            return db.bid_table;
        }

        // GET: api/Bid/5
        [ResponseType(typeof(bid_table))]
        public IHttpActionResult Getbid_table(int id)
        {
            bid_table bid_table = db.bid_table.Find(id);
            if (bid_table == null)
            {
                return NotFound();
            }

            return Ok(bid_table);
        }

        // PUT: api/Bid/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbid_table(int id, bid_table bid_table)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bid_table.bid_id)
            {
                return BadRequest();
            }

            db.Entry(bid_table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bid_tableExists(id))
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

        // POST: api/Bid
        [ResponseType(typeof(bid_table))]
        public IHttpActionResult Postbid_table(bid_table bid_table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bid_table.create_time = DateTime.Now;
            db.bid_table.Add(bid_table);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bid_table.bid_id }, bid_table);
        }

        // DELETE: api/Bid/5
        [ResponseType(typeof(bid_table))]
        public IHttpActionResult Deletebid_table(int id)
        {
            bid_table bid_table = db.bid_table.Find(id);
            if (bid_table == null)
            {
                return NotFound();
            }

            db.bid_table.Remove(bid_table);
            db.SaveChanges();

            return Ok(bid_table);
        }


        [ResponseType(typeof(Object))]
        [Route("api/BiddingStoredProcedure/{ID}")]
        [HttpGet]
        public Object BiddingStoredProcedure(int ID)
        {
            var query = from p in db.products
                        join b in db.bid_table on p.p_id equals b.p_id
                        where p.p_id == ID
                        group new { p, b } by new { p.p_id, p.base_price } into grp
                        select new
                        {
                            ProductId = grp.Key.p_id,
                            HighBid = grp.Max(x => x.b.user_bid_price),
                            BasePrice = grp.Key.base_price
                        };

            var result = query.FirstOrDefault();
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool bid_tableExists(int id)
        {
            return db.bid_table.Count(e => e.bid_id == id) > 0;
        }
    }
}
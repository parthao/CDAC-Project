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
    public class ProductController : ApiController
    {
        private ProjectEntities3 db = new ProjectEntities3();

        // POST: api/Product
        public IQueryable<product> Getproducts()
        {
            return db.products;
        }

        // POST: api/Product/5
        [ResponseType(typeof(product))]
        [Route("api/Products/{id}")]
        [HttpGet]
        public IHttpActionResult Getproduct(int id)
        {
            product product = db.products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Product
        [ResponseType(typeof(product))]
        public IHttpActionResult Postproduct(product product)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.create_time = DateTime.Now;
            db.products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.p_id }, product);
        }
        [ResponseType(typeof(product))]
        [Route("api/GetUserProduct")]
        [HttpPost]
        public IQueryable<product> GetByUsrID([FromBody] product prod)
        {
            IQueryable<product> myproduct = from a in db.products
                              where a.usr_id == prod.usr_id
                              select a;
            return myproduct;
        }

        //SELECT auc_id,p_id FROM aution_table right join products on p_id=product_p_id;
        

        [ResponseType(typeof(Object))]
        [Route("api/GetProductOnJoin")]
        [HttpGet]
        public IQueryable<Object> GetProductOnJoin()
        {
            var result = db.products.GroupJoin(db.aution_table, product => product.p_id,auction => auction.product_p_id,(product, auctions) => new { Product = product, Auctions = auctions })
                .SelectMany(grouped => grouped.Auctions.DefaultIfEmpty(),(grouped, auction) => new { AucId = auction != null ? auction.auc_id : 0,PId = grouped.Product.p_id,PName=grouped.Product.p_name,PCost=grouped.Product.base_price});

            return result;

        }




      
    }
}
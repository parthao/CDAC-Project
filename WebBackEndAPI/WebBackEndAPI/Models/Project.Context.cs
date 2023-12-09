﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBackEndAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProjectEntities3 : DbContext
    {
        public ProjectEntities3()
            : base("name=ProjectEntities3")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aution_table> aution_table { get; set; }
        public virtual DbSet<bid_table> bid_table { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<user_db> user_db { get; set; }
    
        public virtual ObjectResult<Bidding_Result> Bidding(Nullable<int> prodID)
        {
            var prodIDParameter = prodID.HasValue ?
                new ObjectParameter("ProdID", prodID) :
                new ObjectParameter("ProdID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Bidding_Result>("Bidding", prodIDParameter);
        }
    }
}

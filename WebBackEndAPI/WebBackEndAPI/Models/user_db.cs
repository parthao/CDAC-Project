//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class user_db
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user_db()
        {
            this.bid_table = new HashSet<bid_table>();
            this.products = new HashSet<product>();
        }
    
        public int usr_id { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public string pass_w { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string usraddress { get; set; }
        public Nullable<int> pincode { get; set; }
        public string city { get; set; }
        public string statex { get; set; }
        public string country { get; set; }
        public Nullable<System.DateTime> created_At { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public string z { get; set; }
        public string type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bid_table> bid_table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product> products { get; set; }
    }
}
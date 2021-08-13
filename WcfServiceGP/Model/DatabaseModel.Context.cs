﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceGP.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DatabaseEntities1 : DbContext
    {
        public DatabaseEntities1()
            : base("name=DatabaseEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Users> Users { get; set; }
    
        public virtual ObjectResult<Nullable<long>> SPDelUser(Nullable<long> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("SPDelUser", idParameter);
        }
    
        public virtual ObjectResult<SPGetUser_Result> SPGetUser(Nullable<long> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPGetUser_Result>("SPGetUser", idParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> SPSetUser(Nullable<long> id, string name, Nullable<System.DateTime> birthDay, string sex)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(long));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var birthDayParameter = birthDay.HasValue ?
                new ObjectParameter("birthDay", birthDay) :
                new ObjectParameter("birthDay", typeof(System.DateTime));
    
            var sexParameter = sex != null ?
                new ObjectParameter("sex", sex) :
                new ObjectParameter("sex", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("SPSetUser", idParameter, nameParameter, birthDayParameter, sexParameter);
        }
    }
}

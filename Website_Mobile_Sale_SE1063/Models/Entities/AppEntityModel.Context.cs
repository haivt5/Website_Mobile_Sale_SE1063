﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Website_Mobile_Sale_SE1063.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntityManager : DbContext
    {
        public EntityManager()
            : base("name=EntityManager")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}

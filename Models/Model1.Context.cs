﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OsobyZaginioneFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class listazaginonychEntities : DbContext
    {
        public listazaginonychEntities()
            : base("name=listazaginonychEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<osoba> osobas { get; set; }
        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}

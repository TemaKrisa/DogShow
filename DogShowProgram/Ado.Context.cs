﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DogShowProgram
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DogShowEntities : DbContext
    {
        public DogShowEntities()
            : base("name=DogShowEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Award> Award { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Dog> Dog { get; set; }
        public virtual DbSet<DogOwner> DogOwner { get; set; }
        public virtual DbSet<DogPassport> DogPassport { get; set; }
        public virtual DbSet<Expert> Expert { get; set; }
        public virtual DbSet<Performance> Performance { get; set; }
        public virtual DbSet<Ring> Ring { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
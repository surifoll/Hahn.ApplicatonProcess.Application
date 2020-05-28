using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Hahn.ApplicatonProcess.May2020.Data
{
    public interface IApplicationContext
    {
        DbSet<Applicant> Applicants { get; set; }
        void SaveChanges();
    }

    public class ApplicationContext: DbContext, IApplicationContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public void SaveChanges()
        {
            this.SaveChanges();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Applicant>(entity =>
            {
                // Set key for entity
                entity.HasKey(p => p.ID);
            });


            base.OnModelCreating(builder);
        }
    }
}

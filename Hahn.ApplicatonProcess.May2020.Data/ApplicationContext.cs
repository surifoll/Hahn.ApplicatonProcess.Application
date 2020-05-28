using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Hahn.ApplicatonProcess.May2020.Data
{

    public class ApplicationContext: DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
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

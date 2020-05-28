using Hahn.ApplicatonProcess.May2020.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.May2020.Data.Repositories
{
    public class ApplicantRepository: IApplicantRepository
    {
        private ApplicationContext _context;

        public ApplicantRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Applicant GetById(int id)
        {
            var record = _context.Applicants.FirstOrDefault(p => p.ID == id);
            return record;
        }

        public IEnumerable<Applicant> GetAll()
        {
            var results = _context.Applicants;

            return results.ToList();
        }

        public Applicant Add(Applicant entity)
        {
            _context.Applicants.Add(entity);
            _context.SaveChanges();
            return entity;
        } 

        public void Update(Applicant entity)
        {
            
            _context.Applicants.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Applicant entity)
        {
            _context.Applicants.Remove(entity);
            _context.SaveChanges();
        }
    }
}

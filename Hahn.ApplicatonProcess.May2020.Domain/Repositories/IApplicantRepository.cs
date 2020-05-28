using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.May2020.Domain.Repositories
{
    public interface IApplicantRepository
    {
        Applicant GetById(int id);
        IEnumerable<Applicant> GetAll();
        Applicant Add(Applicant entity);
        void Update(Applicant entity);
        void Delete(Applicant entity);

    }
}

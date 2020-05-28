using System.Collections.Generic;
using System.Text;
using Hahn.ApplicatonProcess.May2020.Domain.Models;

namespace Hahn.ApplicatonProcess.May2020.Domain.Services
{
    public interface IApplicantService
    {
        ApplicantModel GetById(int id);
        IEnumerable<ApplicantModel> GetAll();
        ApplicantModel Add(ApplicantModel entity);
        void Update(int id, ApplicantModel entity);
        void Delete(int entity);
    }
}

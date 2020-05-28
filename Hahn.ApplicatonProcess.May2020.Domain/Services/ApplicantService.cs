using System;
using System.Collections.Generic;
using System.Linq;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Domain.Repositories;

namespace Hahn.ApplicatonProcess.May2020.Domain.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _repository;

        public ApplicantService(IApplicantRepository repository)
        {
            _repository = repository;
        }

        public ApplicantModel GetById(int id)
        {
            var applicant = _repository.GetById(id);
            if (applicant != null)
            {
                var result = new ApplicantModel
                {
                    ID = applicant.ID,
                    Name = applicant.Name,
                    FamilyName = applicant.FamilyName,
                    Address = applicant.Address,
                    CountryOfOrigin = applicant.CountryOfOrigin,
                    EMailAddress = applicant.EMailAddress,
                    Age = applicant.Age,
                    Hired = applicant.Hired
                };
                return result;
            }

            return null;
        }

        public IEnumerable<ApplicantModel> GetAll()
        {
            var applicants = _repository.GetAll();
            var result = applicants?.Select(p => new ApplicantModel()
            {
                ID = p.ID,
                Name = p.Name,
                FamilyName = p.FamilyName,
                Address = p.Address,
                CountryOfOrigin = p.CountryOfOrigin,
                EMailAddress = p.EMailAddress,
                Age = p.Age,
                Hired = p.Hired
            });
            return result;
        }

        public ApplicantModel Add(ApplicantModel model)
        {
            var entity = new Applicant()
            {
                Name = model.Name,
                FamilyName = model.FamilyName,
                Address = model.Address,
                CountryOfOrigin = model.CountryOfOrigin,
                EMailAddress = model.EMailAddress,
                Age = model.Age,
                Hired = model.Hired
            };
           var result = _repository.Add(entity);
           model.ID = result.ID;
           return model;
        }

        public void Update(int id, ApplicantModel model)
        {
            var entity = _repository.GetById(id);
            entity.Name = model.Name;
            entity.FamilyName = model.FamilyName;
            entity.Address = model.Address;
            entity.CountryOfOrigin = model.CountryOfOrigin;
            entity.EMailAddress = model.EMailAddress;
            entity.Age = model.Age;
            entity.Hired = model.Hired;
            _repository.Update(entity);

        }

        public void Delete(int entityId)
        {
            var entity = _repository.GetById(entityId);
            _repository.Delete(entity);
        }
    }
}
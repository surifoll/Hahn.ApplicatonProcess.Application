using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using Hahn.ApplicatonProcess.May2020.Data;
using Hahn.ApplicatonProcess.May2020.Data.Repositories;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Hahn.ApplicatonProcess.May2020.Domain.Repositories;
using Hahn.ApplicatonProcess.May2020.Domain.Services;
using Hahn.ApplicatonProcess.My20202.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Hahn.ApplicatonProcess.My20202.Tests.Repositories
{
    public class ApplicantRepositoryTests
    {
        private ApplicantRepository _query;
        private AutoMoqer _mocker;
        private Applicant _applicant;

        private const int Id = 1;
        private const string Email = "surifoll@yahoo.com";
        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMoqer();

            _applicant = new Applicant()
            {
                ID = Id,
                EMailAddress = Email
            };

            // _mocker.GetMock<DbSet<Applicant>>()
            //     .SetUpDbSet(new List<Applicant> { _applicant });

            _mocker.GetMock<ApplicationContext>()
                .Setup(p => p.Applicants)
                .Returns(_mocker.GetMock<Microsoft.EntityFrameworkCore.DbSet<Applicant>>().Object);

            _query = _mocker.Create<ApplicantRepository>();
        }

       
    }
}
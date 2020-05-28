using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using NUnit.Framework;

namespace Hahn.ApplicatonProcess.My20202.Tests.Domains
{
    public class ApplicantTests
    {
        private Applicant _applicant;
        public const int Id = 1;
        public const string EMailAddress = "surifoll@yahoo.com";

        [SetUp]
        public void Setup()
        {
            _applicant = new Applicant();
        }

        [Test]
        public void TestGetterAndSetterId()
        {
            _applicant.ID = Id;
            Assert.That(_applicant.ID, Is.EqualTo(Id));
        }
        [Test]
        public void TestGetterAndSetterEMailAddress()
        {
            _applicant.EMailAddress = EMailAddress;
            Assert.That(_applicant.EMailAddress, Is.EqualTo(Id));
        }
        
    }
}

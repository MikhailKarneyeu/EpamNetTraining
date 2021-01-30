using Microsoft.SqlServer.Dac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityDAL.Entities;
using UniversityDAL.Services;

namespace UniversityDALIntegrationTests.Tests
{
    class SpecialtyDAOTests
    {
        private string _connectionString;
        private static readonly object[] _specialtysList =
            new object[]
            {
                new List<Specialty>
                {
                    new Specialty(1, "Specialty1"),
                    new Specialty(2, "Specialty2"),
                    new Specialty(3, "Specialty3")
                }
            };

        [SetUp]
        public void Init()
        {
            const string connectionString = "Server=localhost\\sqlexpress;Database=university_TestDB;Integrated Security=True";
            _connectionString = connectionString;
        }

        [TearDown]
        public void RevertStorage()
        {
            const string dacPacName = "university_TestDB.dacpac";
            var path = $"..\\..\\..\\Dacpac\\{dacPacName}";
            var dacPack = new DacServices(_connectionString);
            var dacOptions = new DacDeployOptions { CreateNewDatabase = true };
            using var dp = DacPackage.Load(path);
            dacPack.Deploy(dp, @"university_TestDB", true, dacOptions);
        }

        [Test, TestCaseSource(nameof(_specialtysList))]
        public void Create_ValidEntity_RecordCreated(List<Specialty> specialtys)
        {
            var testSpecialty = new Specialty(4, "Specialty4");
            var specialtyDAO = new SpecialtyDAOCreator().Create(_connectionString);
            //Act
            specialtyDAO.Create(testSpecialty);
            var specialtyList = specialtyDAO.GetAll();
            //Assert
            Assert.IsTrue(specialtyList.Contains(testSpecialty));
        }

        [Test, TestCaseSource(nameof(_specialtysList))]
        public void DeleteById_CorrectId_RecordDeleted(List<Specialty> specialtys)
        {
            //Arrange
            var testSpecialty = new Specialty(4, "Specialty4");
            var specialtyDAO = new SpecialtyDAOCreator().Create(_connectionString);
            specialtyDAO.Create(testSpecialty);
            var specialtyList = specialtyDAO.GetAll();
            var specialtyExist = specialtyList.Contains(testSpecialty);
            //Act
            var result = specialtyDAO.DeleteById(4);
            specialtyList = specialtyDAO.GetAll();
            //Assert
            Assert.IsTrue(result && specialtyExist && !specialtyList.Contains(testSpecialty));
        }

        [Test, TestCaseSource(nameof(_specialtysList))]
        public void GetAll_GotAllRecords(List<Specialty> specialtys)
        {
            //Arrange
            var specialtyDAO = new SpecialtyDAOCreator().Create(_connectionString);
            //Act
            var specialtyList = specialtyDAO.GetAll();
            //Assert
            Assert.IsTrue(specialtyList.SequenceEqual(specialtys));
        }

        [Test, TestCaseSource(nameof(_specialtysList))]
        public void GetById_ValidEntity_GotRecord(List<Specialty> specialtys)
        {
            //Arrange
            var specialtyDAO = new SpecialtyDAOCreator().Create(_connectionString);
            //Act
            var result = specialtyDAO.GetById(3);
            //Assert
            Assert.IsTrue(result.Equals(specialtys[2]));
        }

        [Test, TestCaseSource(nameof(_specialtysList))]
        public void Update_ValidEntity_RecordUpdated(List<Specialty> specialtys)
        {
            //Arrange
            var testSpecialty = new Specialty(2, "NewName");
            var specialtyDAO = new SpecialtyDAOCreator().Create(_connectionString);
            //Act
            specialtyDAO.Update(testSpecialty);
            var specialtyList = specialtyDAO.GetAll();
            //Assert
            Assert.IsTrue(specialtyList[1].Equals(testSpecialty));
        }
    }
}

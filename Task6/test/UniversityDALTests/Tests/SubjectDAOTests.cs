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
    class SubjectDAOTests
    {
        private string _connectionString;
        private static readonly object[] _subjectsList =
            new object[]
            {
                new List<Subject>
                {
                    new Subject(1, "Subject1"),
                    new Subject(2, "Subject2"),
                    new Subject(3, "Subject3"),
                    new Subject(4, "Subject4"),
                    new Subject(5, "Subject5"),
                    new Subject(6, "Subject6")
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

        [Test, TestCaseSource(nameof(_subjectsList))]
        public void Create_ValidEntity_RecordCreated(List<Subject> subjects)
        {
            var testSubject = new Subject(7, "Subject7");
            var subjectDAO = new SubjectDAOCreator().Create(_connectionString);
            //Act
            subjectDAO.Create(testSubject);
            var subjectList = subjectDAO.GetAll();
            //Assert
            Assert.IsTrue(subjectList.Contains(testSubject));
        }

        [Test, TestCaseSource(nameof(_subjectsList))]
        public void DeleteById_CorrectId_RecordDeleted(List<Subject> subjects)
        {
            //Arrange
            var testSubject = new Subject(7, "Subject7");
            var subjectDAO = new SubjectDAOCreator().Create(_connectionString);
            subjectDAO.Create(testSubject);
            var subjectList = subjectDAO.GetAll();
            var subjectExist = subjectList.Contains(testSubject);
            //Act
            var result = subjectDAO.DeleteById(7);
            subjectList = subjectDAO.GetAll();
            //Assert
            Assert.IsTrue(result && subjectExist && !subjectList.Contains(testSubject));
        }

        [Test, TestCaseSource(nameof(_subjectsList))]
        public void GetAll_GotAllRecords(List<Subject> subjects)
        {
            //Arrange
            var subjectDAO = new SubjectDAOCreator().Create(_connectionString);
            //Act
            var subjectList = subjectDAO.GetAll();
            //Assert
            Assert.IsTrue(subjectList.SequenceEqual(subjects));
        }

        [Test, TestCaseSource(nameof(_subjectsList))]
        public void GetById_ValidEntity_GotRecord(List<Subject> subjects)
        {
            //Arrange
            var subjectDAO = new SubjectDAOCreator().Create(_connectionString);
            //Act
            var result = subjectDAO.GetById(3);
            //Assert
            Assert.IsTrue(result.Equals(subjects[2]));
        }

        [Test, TestCaseSource(nameof(_subjectsList))]
        public void Update_ValidEntity_RecordUpdated(List<Subject> subjects)
        {
            //Arrange
            var testSubject = new Subject(4, "NewName");
            var subjectDAO = new SubjectDAOCreator().Create(_connectionString);
            //Act
            subjectDAO.Update(testSubject);
            var subjectList = subjectDAO.GetAll();
            //Assert
            Assert.IsTrue(subjectList[3].Equals(testSubject));
        }
    }
}

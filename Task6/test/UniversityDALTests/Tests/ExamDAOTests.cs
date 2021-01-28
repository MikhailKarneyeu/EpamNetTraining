using Microsoft.SqlServer.Dac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversityDAL.Entities;
using UniversityDAL.Services;

namespace UniversityDALIntegrationTests.Tests
{
    public class ExamDAOTests
    {
        private string _connectionString;
        private static readonly object[] _exams =
            new object[]
            {
                new List<Exam>
                {
                    new Exam(1, 1, 1, Convert.ToDateTime("25.05.2019 00:00:00")),
                    new Exam(2, 1, 2, Convert.ToDateTime("28.05.2019 00:00:00")),
                    new Exam(3, 1, 3, Convert.ToDateTime("31.05.2019 00:00:00")),
                    new Exam(4, 2, 4, Convert.ToDateTime("24.12.2019 00:00:00")),
                    new Exam(5, 2, 5, Convert.ToDateTime("27.12.2019 00:00:00")),
                    new Exam(6, 2, 6, Convert.ToDateTime("30.12.2019 00:00:00")),
                    new Exam(7, 3, 1, Convert.ToDateTime("23.05.2020 00:00:00")),
                    new Exam(8, 3, 2, Convert.ToDateTime("26.05.2020 00:00:00")),
                    new Exam(9, 3, 3, Convert.ToDateTime("29.05.2020 00:00:00")),
                    new Exam(10, 4, 4, Convert.ToDateTime("25.12.2020 00:00:00")),
                    new Exam(11, 4, 5, Convert.ToDateTime("27.12.2020 00:00:00")),
                    new Exam(12, 4, 6, Convert.ToDateTime("30.12.2020 00:00:00"))
                }
            };

        [SetUp]
        public void Init()
        {
            _connectionString = ConnectionStringConfig.GetConnectionString();
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

        [Test, TestCaseSource(nameof(_exams))]
        public void Create_ValidEntity_RecordCreated(List<Exam> exams)
        {
            //Arrange
            var testExam = new Exam(13, 4, 6, Convert.ToDateTime("30.12.2020 08:00:00"));
            var examDAO = new ExamDAOCreator().Create(_connectionString);
            //Act
            examDAO.Create(testExam);
            var examList = examDAO.GetAll();
            //Assert
            Assert.IsTrue(examList.Contains(testExam));
        }

        [Test, TestCaseSource(nameof(_exams))]
        public void DeleteById_CorrectId_RecordDeleted(List<Exam> exams)
        {
            //Arrange
            var testExam = new Exam(13, 4, 6, Convert.ToDateTime("30.12.2020 08:00:00"));
            var examDAO = new ExamDAOCreator().Create(_connectionString);
            examDAO.Create(testExam);
            var examList = examDAO.GetAll();
            var examExist = examList.Contains(testExam);
            //Act
            var result = examDAO.DeleteById(13);
            examList = examDAO.GetAll();
            //Assert
            Assert.IsTrue(result&&examExist&&!examList.Contains(testExam));
        }

        [Test, TestCaseSource(nameof(_exams))]
        public void GetAll_GotAllRecords(List<Exam> exams)
        {
            //Arrange
            var examDAO = new ExamDAOCreator().Create(_connectionString);
            //Act
            var examList = examDAO.GetAll();
            //Assert
            Assert.IsTrue(examList.SequenceEqual(exams));
        }

        [Test, TestCaseSource(nameof(_exams))]
        public void GetById_ValidEntity_GotRecord(List<Exam> exams)
        {
            //Arrange
            var examDAO = new ExamDAOCreator().Create(_connectionString);
            //Act
            var result = examDAO.GetById(4);
            //Assert
            Assert.IsTrue(result.Equals(exams[3]));
        }

        [Test, TestCaseSource(nameof(_exams))]
        public void Update_ValidEntity_RecordUpdated(List<Exam> exams)
        {
            //Arrange
            var testExam = new Exam(4, 2, 5, Convert.ToDateTime("30.05.2020 08:00:00"));
            var examDAO = new ExamDAOCreator().Create(_connectionString);
            //Act
            examDAO.Update(testExam);
            var examList = examDAO.GetAll();
            //Assert
            Assert.IsTrue(examList[3].Equals(testExam));
        }
    }
}
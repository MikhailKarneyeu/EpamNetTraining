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
        private static readonly List<Session> _sessions = new List<Session>
            {
                new Session(1, "Session1", Convert.ToDateTime("24.12.2020"), Convert.ToDateTime("07.01.2021")),
                new Session(2, "Session2", Convert.ToDateTime("24.05.2020"), Convert.ToDateTime("07.06.2020"))
            };

        private static readonly object[] _exams =
            new object[]
            {
                new List<Exam>
                {
                    new Exam(1, _sessions[0], "ExamName1", Convert.ToDateTime("24.12.2020 08:00:00")),
                    new Exam(2, _sessions[0], "ExamName2", Convert.ToDateTime("27.12.2020 08:00:00")),
                    new Exam(3, _sessions[0], "ExamName3", Convert.ToDateTime("30.12.2020 08:00:00")),
                    new Exam(4, _sessions[1], "ExamName4", Convert.ToDateTime("28.05.2020 08:00:00"))
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
            var testExam = new Exam(5, _sessions[1], "ExamName5", Convert.ToDateTime("30.05.2020 08:00:00"));
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
            var testExam = new Exam(5, _sessions[1], "ExamName5", Convert.ToDateTime("30.05.2020 08:00:00"));
            var examDAO = new ExamDAOCreator().Create(_connectionString);
            examDAO.Create(testExam);
            var examList = examDAO.GetAll();
            var examExist = examList.Contains(testExam);
            //Act
            var result = examDAO.DeleteById(5);
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
            var testExam = new Exam(4, _sessions[1], "ExamName4Updated", Convert.ToDateTime("30.05.2020 08:00:00"));
            var examDAO = new ExamDAOCreator().Create(_connectionString);
            //Act
            examDAO.Update(testExam);
            var examList = examDAO.GetAll();
            //Assert
            Assert.IsTrue(examList[3].Equals(testExam));
        }
    }
}
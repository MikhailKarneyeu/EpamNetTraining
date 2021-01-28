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
    class ExamResultDAOTests
    {
        private string _connectionString;
        private static readonly object[] _examResults =
        {
            new object[]
            {
                new List<ExamResult>
                {
                    new ExamResult(1, 1, 1, "2"),
                    new ExamResult(2, 1, 2, "7"),
                    new ExamResult(3, 1, 3, "8"),
                    new ExamResult(4, 1, 4, "8"),
                    new ExamResult(5, 1, 5, "8"),
                    new ExamResult(6, 1, 6, "2"),
                    new ExamResult(7, 2, 1, "2"),
                    new ExamResult(8, 2, 2, "8"),
                    new ExamResult(9, 2, 3, "2"),
                    new ExamResult(10, 2, 4, "8"),
                    new ExamResult(11, 2, 5, "8"),
                    new ExamResult(12, 2, 6, "8"),
                    new ExamResult(13, 3, 1, "2"),
                    new ExamResult(14, 3, 2, "2"),
                    new ExamResult(15, 3, 3, "2"),
                    new ExamResult(16, 3, 4, "8"),
                    new ExamResult(17, 3, 5, "8"),
                    new ExamResult(18, 3, 6, "8"),
                    new ExamResult(19, 4, 1, "8"),
                    new ExamResult(20, 4, 2, "8"),
                    new ExamResult(21, 4, 3, "8"),
                    new ExamResult(22, 4, 4, "8"),
                    new ExamResult(23, 4, 5, "8"),
                    new ExamResult(24, 4, 6, "8"),
                    new ExamResult(25, 5, 1, "8"),
                    new ExamResult(26, 5, 2, "2"),
                    new ExamResult(27, 5, 3, "8"),
                    new ExamResult(28, 5, 4, "8"),
                    new ExamResult(29, 5, 5, "8"),
                    new ExamResult(30, 5, 6, "8"),
                    new ExamResult(31, 6, 1, "8"),
                    new ExamResult(32, 6, 2, "8"),
                    new ExamResult(33, 6, 3, "8"),
                    new ExamResult(34, 6, 4, "8"),
                    new ExamResult(35, 6, 5, "8"),
                    new ExamResult(36, 6, 6, "8"),
                    new ExamResult(37, 7, 1, "8"),
                    new ExamResult(38, 7, 2, "8"),
                    new ExamResult(39, 7, 3, "8"),
                    new ExamResult(40, 7, 4, "8"),
                    new ExamResult(41, 7, 5, "8"),
                    new ExamResult(42, 7, 6, "8"),
                    new ExamResult(43, 8, 1, "8"),
                    new ExamResult(44, 8, 2, "8"),
                    new ExamResult(45, 8, 3, "8"),
                    new ExamResult(46, 8, 4, "8"),
                    new ExamResult(47, 8, 5, "8"),
                    new ExamResult(48, 8, 6, "8"),
                    new ExamResult(49, 9, 1, "8"),
                    new ExamResult(50, 9, 2, "8"),
                    new ExamResult(51, 9, 3, "8"),
                    new ExamResult(52, 9, 4, "8"),
                    new ExamResult(53, 9, 5, "8"),
                    new ExamResult(54, 9, 6, "8"),
                    new ExamResult(55, 10, 1, "8"),
                    new ExamResult(56, 10, 2, "8"),
                    new ExamResult(57, 10, 3, "8"),
                    new ExamResult(58, 10, 4, "8"),
                    new ExamResult(59, 10, 5, "8"),
                    new ExamResult(60, 10, 6, "8"),
                    new ExamResult(61, 11, 1, "8"),
                    new ExamResult(62, 11, 2, "8"),
                    new ExamResult(63, 11, 3, "8"),
                    new ExamResult(64, 11, 4, "8"),
                    new ExamResult(65, 11, 5, "8"),
                    new ExamResult(66, 11, 6, "8"),
                    new ExamResult(67, 12, 1, "8"),
                    new ExamResult(68, 12, 2, "8"),
                    new ExamResult(69, 12, 3, "8"),
                    new ExamResult(70, 12, 4, "8"),
                    new ExamResult(71, 12, 5, "8"),
                    new ExamResult(72, 12, 6, "8")
                }
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

        [Test, TestCaseSource(nameof(_examResults))]
        public void Create_ValidEntity_RecordCreated(List<ExamResult> examResults)
        {
            var testExamResult = new ExamResult(73, 12, 6, "8");
            var examResultDAO = new ExamResultDAOCreator().Create(_connectionString);
            //Act
            examResultDAO.Create(testExamResult);
            var examResultList = examResultDAO.GetAll();
            //Assert
            Assert.IsTrue(examResultList.Contains(testExamResult));
        }

        [Test, TestCaseSource(nameof(_examResults))]
        public void DeleteById_CorrectId_RecordDeleted(List<ExamResult> examResults)
        {
            //Arrange
            var testExamResult = new ExamResult(73, 6, 6, "8");
            var examResultDAO = new ExamResultDAOCreator().Create(_connectionString);
            examResultDAO.Create(testExamResult);
            var examResultList = examResultDAO.GetAll();
            var examExist = examResultList.Contains(testExamResult);
            //Act
            var result = examResultDAO.DeleteById(73);
            examResultList = examResultDAO.GetAll();
            //Assert
            Assert.IsTrue(result && examExist && !examResultList.Contains(testExamResult));
        }

        [Test, TestCaseSource(nameof(_examResults))]
        public void GetAll_GotAllRecords(List<ExamResult> examResults)
        {
            //Arrange
            var examResultDAO = new ExamResultDAOCreator().Create(_connectionString);
            //Act
            var examResultList = examResultDAO.GetAll();
            //Assert
            Assert.IsTrue(examResultList.SequenceEqual(examResults));
        }

        [Test, TestCaseSource(nameof(_examResults))]
        public void GetById_ValidEntity_GotRecord(List<ExamResult> examResults)
        {
            //Arrange
            var examResultDAO = new ExamResultDAOCreator().Create(_connectionString);
            //Act
            var result = examResultDAO.GetById(4);
            //Assert
            Assert.IsTrue(result.Equals(examResults[3]));
        }

        [Test, TestCaseSource(nameof(_examResults))]
        public void Update_ValidEntity_RecordUpdated(List<ExamResult> examResults)
        {
            //Arrange
            var testExamResult = new ExamResult(20, 2, 2, "9");
            var examResultDAO = new ExamResultDAOCreator().Create(_connectionString);
            //Act
            examResultDAO.Update(testExamResult);
            var examResultList = examResultDAO.GetAll();
            //Assert
            Assert.IsTrue(examResultList[19].Equals(testExamResult));
        }
    }
}

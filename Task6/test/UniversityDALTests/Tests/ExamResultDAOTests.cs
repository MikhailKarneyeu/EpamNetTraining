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
        private static readonly List<Session> _sessions = new List<Session>
            {
                new Session(1, "Session1", Convert.ToDateTime("24.12.2020"), Convert.ToDateTime("07.01.2021")),
                new Session(2, "Session2", Convert.ToDateTime("24.05.2020"), Convert.ToDateTime("07.06.2020"))
            };

        private static readonly List<Exam> _exams =
            new List<Exam>
            {
                new Exam(1, _sessions[0], "ExamName1", Convert.ToDateTime("24.12.2020 08:00:00")),
                new Exam(2, _sessions[0], "ExamName2", Convert.ToDateTime("27.12.2020 08:00:00")),
                new Exam(3, _sessions[0], "ExamName3", Convert.ToDateTime("30.12.2020 08:00:00")),
                new Exam(4, _sessions[1], "ExamName4", Convert.ToDateTime("28.05.2020 08:00:00"))
            };

        private static readonly List<Group> _groups =
            new List<Group>
            {
                new Group(1, "Group1"),
                new Group(2, "Group2"),
                new Group(3, "Group3")
            };

        private static readonly List<Student> _students =
            new List<Student>
            {
                new Student(1, _groups[0], "FullName1", "Female", Convert.ToDateTime("12.02.2000")),
                new Student(2, _groups[0], "FullName2", "Male", Convert.ToDateTime("14.08.2000")),
                new Student(3, _groups[1], "FullName3", "FMale", Convert.ToDateTime("09.03.2000")),
                new Student(4, _groups[1], "FullName4", "Male", Convert.ToDateTime("15.04.2001")),
                new Student(5, _groups[2], "FullName5", "Male", Convert.ToDateTime("03.03.2000"))
            };

        private static readonly object[] _examResults =
        {
            new object[]
            {
                new List<ExamResult>
                {
                    new ExamResult(1, _exams[0], _students[0], "8"),
                    new ExamResult(2, _exams[0], _students[1], "3"),
                    new ExamResult(3, _exams[0], _students[2], "2"),
                    new ExamResult(4, _exams[0], _students[3], "7"),
                    new ExamResult(5, _exams[0], _students[4], "9"),
                    new ExamResult(6, _exams[1], _students[0], "7"),
                    new ExamResult(7, _exams[1], _students[1], "2"),
                    new ExamResult(8, _exams[1], _students[2], "3"),
                    new ExamResult(9, _exams[1], _students[3], "7"),
                    new ExamResult(10, _exams[1], _students[4], "9"),
                    new ExamResult(11, _exams[2], _students[0], "7"),
                    new ExamResult(12, _exams[2], _students[1], "3"),
                    new ExamResult(13, _exams[2], _students[2], "3"),
                    new ExamResult(14, _exams[2], _students[3], "2"),
                    new ExamResult(15, _exams[2], _students[4], "9"),
                    new ExamResult(16, _exams[3], _students[0], "7"),
                    new ExamResult(17, _exams[3], _students[1], "9"),
                    new ExamResult(18, _exams[3], _students[2], "2"),
                    new ExamResult(19, _exams[3], _students[3], "7"),
                    new ExamResult(20, _exams[3], _students[4], "8")
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
            var testExamResult = new ExamResult(21, _exams[3], _students[4], "9");
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
            var testExamResult = new ExamResult(21, _exams[3], _students[4], "7");
            var examResultDAO = new ExamResultDAOCreator().Create(_connectionString);
            examResultDAO.Create(testExamResult);
            var examList = examResultDAO.GetAll();
            var examExist = examList.Contains(testExamResult);
            //Act
            var result = examResultDAO.DeleteById(21);
            examList = examResultDAO.GetAll();
            //Assert
            Assert.IsTrue(result && examExist && !examList.Contains(testExamResult));
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
            var testExamResult = new ExamResult(20, _exams[3], _students[4], "9");
            var examResultDAO = new ExamResultDAOCreator().Create(_connectionString);
            //Act
            examResultDAO.Update(testExamResult);
            var examList = examResultDAO.GetAll();
            //Assert
            Assert.IsTrue(examList[19].Equals(testExamResult));
        }
    }
}

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
    class StudentDAOTests
    {
        private string _connectionString;

        private static readonly List<Group> _groups =
            new List<Group>
            {
                new Group(1, "Group1"),
                new Group(2, "Group2"),
                new Group(3, "Group3")
            };

        private static readonly object[] _students =
            new object[]
            {
                new List<Student>
                {
                    new Student(1, _groups[0], "FullName1", "Female", Convert.ToDateTime("12.02.2000")),
                    new Student(2, _groups[0], "FullName2", "Male", Convert.ToDateTime("14.08.2000")),
                    new Student(3, _groups[1], "FullName3", "FMale", Convert.ToDateTime("09.03.2000")),
                    new Student(4, _groups[1], "FullName4", "Male", Convert.ToDateTime("15.04.2001")),
                    new Student(5, _groups[2], "FullName5", "Male", Convert.ToDateTime("03.03.2000"))
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

        [Test, TestCaseSource(nameof(_students))]
        public void Create_ValidEntity_RecordCreated(List<Student> students)
        {
            var testStudent = new Student(6, _groups[2], "FullName6", "Male", Convert.ToDateTime("03.03.2000"));
            var studentDAO = new StudentDAOCreator().Create(_connectionString);
            //Act
            studentDAO.Create(testStudent);
            var studentList = studentDAO.GetAll();
            //Assert
            Assert.IsTrue(studentList.Contains(testStudent));
        }

        [Test, TestCaseSource(nameof(_students))]
        public void DeleteById_CorrectId_RecordDeleted(List<Student> students)
        {
            //Arrange
            var testStudent = new Student(6, _groups[2], "FullName6", "Male", Convert.ToDateTime("03.03.2000"));
            var studentDAO = new StudentDAOCreator().Create(_connectionString);
            studentDAO.Create(testStudent);
            var examList = studentDAO.GetAll();
            var examExist = examList.Contains(testStudent);
            //Act
            var result = studentDAO.DeleteById(6);
            examList = studentDAO.GetAll();
            //Assert
            Assert.IsTrue(result && examExist && !examList.Contains(testStudent));
        }

        [Test, TestCaseSource(nameof(_students))]
        public void GetAll_GotAllRecords(List<Student> students)
        {
            //Arrange
            var studentDAO = new StudentDAOCreator().Create(_connectionString);
            //Act
            var studentList = studentDAO.GetAll();
            //Assert
            Assert.IsTrue(studentList.SequenceEqual(students));
        }

        [Test, TestCaseSource(nameof(_students))]
        public void GetById_ValidEntity_GotRecord(List<Student> students)
        {
            //Arrange
            var studentDAO = new StudentDAOCreator().Create(_connectionString);
            //Act
            var result = studentDAO.GetById(4);
            //Assert
            Assert.IsTrue(result.Equals(students[3]));
        }

        [Test, TestCaseSource(nameof(_students))]
        public void Update_ValidEntity_RecordUpdated(List<Student> students)
        {
            //Arrange
            var testStudent = new Student(5, _groups[2], "FullName5Updated", "Male", Convert.ToDateTime("03.03.2000"));
            var studentDAO = new StudentDAOCreator().Create(_connectionString);
            //Act
            studentDAO.Update(testStudent);
            var examList = studentDAO.GetAll();
            //Assert
            Assert.IsTrue(examList[4].Equals(testStudent));
        }
    }
}

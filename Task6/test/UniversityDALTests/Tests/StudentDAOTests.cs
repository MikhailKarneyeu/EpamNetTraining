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

        private static readonly object[] _students =
            new object[]
            {
                new List<Student>
                {
                    new Student(1, 1, "StudentName1", "Male", Convert.ToDateTime("08.03.2001")),
                    new Student(2, 1, "StudentName2", "Female", Convert.ToDateTime("12.05.2001")),
                    new Student(3, 2, "StudentName3", "Male", Convert.ToDateTime("21.02.2000")),
                    new Student(4, 2, "StudentName4", "Male", Convert.ToDateTime("12.05.2000")),
                    new Student(5, 3, "StudentName5", "Female", Convert.ToDateTime("01.07.2001")),
                    new Student(6, 3, "StudentName6", "Male", Convert.ToDateTime("15.11.2000"))
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
            var testStudent = new Student(7, 3, "StudentName7", "Male", Convert.ToDateTime("03.03.2000"));
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
            var testStudent = new Student(7, 3, "StudentName7", "Male", Convert.ToDateTime("03.03.2000"));
            var studentDAO = new StudentDAOCreator().Create(_connectionString);
            studentDAO.Create(testStudent);
            var studentList = studentDAO.GetAll();
            var examExist = studentList.Contains(testStudent);
            //Act
            var result = studentDAO.DeleteById(7);
            studentList = studentDAO.GetAll();
            //Assert
            Assert.IsTrue(result && examExist && !studentList.Contains(testStudent));
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
            var testStudent = new Student(5, 3, "Student5Updated", "Male", Convert.ToDateTime("03.03.2000"));
            var studentDAO = new StudentDAOCreator().Create(_connectionString);
            //Act
            studentDAO.Update(testStudent);
            var studentList = studentDAO.GetAll();
            //Assert
            Assert.IsTrue(studentList[4].Equals(testStudent));
        }
    }
}

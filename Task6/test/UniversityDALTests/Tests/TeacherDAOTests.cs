using Microsoft.SqlServer.Dac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UniversityDAL.Entities;
using UniversityDAL.Services;

namespace UniversityDALIntegrationTests.Tests
{
    class TeacherDAOTests
    {
        private string _connectionString;
        private static readonly object[] _teachersList =
            new object[]
            {
                new List<Teacher>
                {
                    new Teacher(1, "Teacher1"),
                    new Teacher(2, "Teacher2"),
                    new Teacher(3, "Teacher3")
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

        [Test, TestCaseSource(nameof(_teachersList))]
        public void Create_ValidEntity_RecordCreated(List<Teacher> teachers)
        {
            var testTeacher = new Teacher(4, "Teacher4");
            var teacherDAO = new TeacherDAOCreator().Create(_connectionString);
            //Act
            teacherDAO.Create(testTeacher);
            var teacherList = teacherDAO.GetAll();
            //Assert
            Assert.IsTrue(teacherList.Contains(testTeacher));
        }

        [Test, TestCaseSource(nameof(_teachersList))]
        public void DeleteById_CorrectId_RecordDeleted(List<Teacher> teachers)
        {
            //Arrange
            var testTeacher = new Teacher(4, "Teacher4");
            var teacherDAO = new TeacherDAOCreator().Create(_connectionString);
            teacherDAO.Create(testTeacher);
            var teacherList = teacherDAO.GetAll();
            var teacherExist = teacherList.Contains(testTeacher);
            //Act
            var result = teacherDAO.DeleteById(4);
            teacherList = teacherDAO.GetAll();
            //Assert
            Assert.IsTrue(result && teacherExist && !teacherList.Contains(testTeacher));
        }

        [Test, TestCaseSource(nameof(_teachersList))]
        public void GetAll_GotAllRecords(List<Teacher> teachers)
        {
            //Arrange
            var teacherDAO = new TeacherDAOCreator().Create(_connectionString);
            //Act
            var teacherList = teacherDAO.GetAll();
            //Assert
            Assert.IsTrue(teacherList.SequenceEqual(teachers));
        }

        [Test, TestCaseSource(nameof(_teachersList))]
        public void GetById_ValidEntity_GotRecord(List<Teacher> teachers)
        {
            //Arrange
            var teacherDAO = new TeacherDAOCreator().Create(_connectionString);
            //Act
            var result = teacherDAO.GetById(3);
            //Assert
            Assert.IsTrue(result.Equals(teachers[2]));
        }

        [Test, TestCaseSource(nameof(_teachersList))]
        public void Update_ValidEntity_RecordUpdated(List<Teacher> teachers)
        {
            //Arrange
            var testTeacher = new Teacher(2, "NewName");
            var teacherDAO = new TeacherDAOCreator().Create(_connectionString);
            //Act
            teacherDAO.Update(testTeacher);
            var teacherList = teacherDAO.GetAll();
            //Assert
            Assert.IsTrue(teacherList[1].Equals(testTeacher));
        }
    }
}

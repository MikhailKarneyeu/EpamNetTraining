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
    class GroupDAOTests
    {
        private string _connectionString;
        private static readonly object[] _groupsList =
            new object[]
            {
                new List<Group>
                {
                    new Group(1, 1, "Group1"),
                    new Group(2, 1, "Group2"),
                    new Group(3, 2, "Group3"),
                    new Group(4, 2, "Group4"),
                    new Group(5, 3, "Group5")
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

        [Test, TestCaseSource(nameof(_groupsList))]
        public void Create_ValidEntity_RecordCreated(List<Group> groups)
        {
            var testGroup = new Group(6, 1, "Group6");
            var groupDAO = new GroupDAOCreator().Create(_connectionString);
            //Act
            groupDAO.Create(testGroup);
            var groupList = groupDAO.GetAll();
            //Assert
            Assert.IsTrue(groupList.Contains(testGroup));
        }

        [Test, TestCaseSource(nameof(_groupsList))]
        public void DeleteById_CorrectId_RecordDeleted(List<Group> groups)
        {
            //Arrange
            var testGroup = new Group(6, 1, "Group6");
            var groupDAO = new GroupDAOCreator().Create(_connectionString);
            groupDAO.Create(testGroup);
            var groupList = groupDAO.GetAll();
            var groupExist = groupList.Contains(testGroup);
            //Act
            var result = groupDAO.DeleteById(6);
            groupList = groupDAO.GetAll();
            //Assert
            Assert.IsTrue(result && groupExist && !groupList.Contains(testGroup));
        }

        [Test, TestCaseSource(nameof(_groupsList))]
        public void GetAll_GotAllRecords(List<Group> groups)
        {
            //Arrange
            var groupDAO = new GroupDAOCreator().Create(_connectionString);
            //Act
            var groupList = groupDAO.GetAll();
            //Assert
            Assert.IsTrue(groupList.SequenceEqual(groups));
        }

        [Test, TestCaseSource(nameof(_groupsList))]
        public void GetById_ValidEntity_GotRecord(List<Group> groups)
        {
            //Arrange
            var groupDAO = new GroupDAOCreator().Create(_connectionString);
            //Act
            var result = groupDAO.GetById(3);
            //Assert
            Assert.IsTrue(result.Equals(groups[2]));
        }

        [Test, TestCaseSource(nameof(_groupsList))]
        public void Update_ValidEntity_RecordUpdated(List<Group> groups)
        {
            //Arrange
            var testGroup = new Group(4, 2, "NewName");
            var groupDAO = new GroupDAOCreator().Create(_connectionString);
            //Act
            groupDAO.Update(testGroup);
            var groupList = groupDAO.GetAll();
            //Assert
            Assert.IsTrue(groupList[3].Equals(testGroup));
        }
    }
}

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
    class SessionDAOTests
    {
        private string _connectionString;
        private static readonly object[] _sessions =
            new object[]
            {
                new List<Session>
                {
                    new Session(1, "Session1", Convert.ToDateTime("24.05.2019"), Convert.ToDateTime("07.06.2019")),
                    new Session(2, "Session2", Convert.ToDateTime("23.12.2019"), Convert.ToDateTime("06.01.2020")),
                    new Session(3, "Session3", Convert.ToDateTime("22.05.2020"), Convert.ToDateTime("05.06.2020")),
                    new Session(4, "Session4", Convert.ToDateTime("24.12.2020"), Convert.ToDateTime("07.01.2021"))
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

        [Test, TestCaseSource(nameof(_sessions))]
        public void Create_ValidEntity_RecordCreated(List<Session> sessions)
        {
            var testSession = new Session(5, "Session5", Convert.ToDateTime("24.05.2020"), Convert.ToDateTime("07.06.2020"));
            var sessionDAO = new SessionDAOCreator().Create(_connectionString);
            //Act
            sessionDAO.Create(testSession);
            var sessionList = sessionDAO.GetAll();
            //Assert
            Assert.IsTrue(sessionList.Contains(testSession));
        }

        [Test, TestCaseSource(nameof(_sessions))]
        public void DeleteById_CorrectId_RecordDeleted(List<Session> sessions)
        {
            //Arrange
            var testSession = new Session(5, "Session5", Convert.ToDateTime("24.05.2020"), Convert.ToDateTime("07.06.2020"));
            var sessionDAO = new SessionDAOCreator().Create(_connectionString);
            sessionDAO.Create(testSession);
            var sessionList = sessionDAO.GetAll();
            var examExist = sessionList.Contains(testSession);
            //Act
            var result = sessionDAO.DeleteById(5);
            sessionList = sessionDAO.GetAll();
            //Assert
            Assert.IsTrue(result && examExist && !sessionList.Contains(testSession));
        }

        [Test, TestCaseSource(nameof(_sessions))]
        public void GetAll_GotAllRecords(List<Session> sessions)
        {
            //Arrange
            var sessionDAO = new SessionDAOCreator().Create(_connectionString);
            //Act
            var sessionList = sessionDAO.GetAll();
            //Assert
            Assert.IsTrue(sessionList.SequenceEqual(sessions));
        }

        [Test, TestCaseSource(nameof(_sessions))]
        public void GetById_ValidEntity_GotRecord(List<Session> sessions)
        {
            //Arrange
            var sessionDAO = new SessionDAOCreator().Create(_connectionString);
            //Act
            var result = sessionDAO.GetById(2);
            //Assert
            Assert.IsTrue(result.Equals(sessions[1]));
        }

        [Test, TestCaseSource(nameof(_sessions))]
        public void Update_ValidEntity_RecordUpdated(List<Session> sessions)
        {
            //Arrange
            var testSession = new Session(2, "Session2Updated", Convert.ToDateTime("24.05.2020"), Convert.ToDateTime("07.06.2020"));
            var sessionDAO = new SessionDAOCreator().Create(_connectionString);
            //Act
            sessionDAO.Update(testSession);
            var sessionList = sessionDAO.GetAll();
            //Assert
            Assert.IsTrue(sessionList[1].Equals(testSession));
        }
    }
}

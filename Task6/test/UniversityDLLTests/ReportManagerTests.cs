using Aspose.Cells;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversityBLL;
using UniversityDAL.Entities;
using UniversityDAL.Services;

namespace UniversityDLLTests
{
    public class ReportManagerTests
    {
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
                new Student(1, _groups[0], "Student1", "Female", Convert.ToDateTime("12.02.2000")),
                new Student(2, _groups[0], "Student2", "Male", Convert.ToDateTime("14.08.2000")),
                new Student(3, _groups[1], "Student3", "Male", Convert.ToDateTime("09.03.2000")),
                new Student(4, _groups[1], "Student4", "Male", Convert.ToDateTime("15.04.2001")),
                new Student(5, _groups[2], "Student5", "Male", Convert.ToDateTime("03.03.2000"))
            };

        private static readonly object[] _examResultsLists =
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

        public bool CompareFiles(string filePath1, string filePath2)
        {
            bool result = true;
            Workbook workbook1 = new Workbook(filePath1);
            Workbook workbook2 = new Workbook(filePath2);
            Worksheet worksheet1 = workbook1.Worksheets["Sheet1"];
            Worksheet worksheet2 = workbook2.Worksheets["Sheet1"];
            foreach(Cell c in worksheet1.Cells)
            {
                if (!c.Value.Equals(worksheet2.Cells[c.Row, c.Column].Value))
                    result = false;
            }
            return result;
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessinResults_ValidData_ShouldSaveTable(List<ExamResult> examResults)
        {
            //Arrange
            string filePath = @"..\..\..\TestFiles\SessionResult.xlsx";
            string testFilePath = @"..\..\..\TestFiles\TestSessionResult.xlsx";
            string sessionName = "Session1";
            var examDAOCreatorMock = new Mock<DAOCreator<Exam>>();
            var examResultDAOCreatorMock = new Mock<DAOCreator<ExamResult>>();
            var groupDAOCreatorMock = new Mock<DAOCreator<Group>>();
            var sessionDAOCreatorMock = new Mock<DAOCreator<Session>>();
            var studentDAOCreatorMock = new Mock<DAOCreator<Student>>();
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object);
            //Act
            reportManager.SaveSessionResults(sessionName ,filePath, null);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessinResults_ValidDataStudentSorted_ShouldSaveStudentSortedTable(List<ExamResult> examResults)
        {
            //Arrange
            string filePath = @"..\..\..\TestFiles\SessionResultStudentSorted.xlsx";
            string testFilePath = @"..\..\..\TestFiles\TestSessionResultStudentSorted.xlsx";
            string sessionName = "Session1";
            var examDAOCreatorMock = new Mock<DAOCreator<Exam>>();
            var examResultDAOCreatorMock = new Mock<DAOCreator<ExamResult>>();
            var groupDAOCreatorMock = new Mock<DAOCreator<Group>>();
            var sessionDAOCreatorMock = new Mock<DAOCreator<Session>>();
            var studentDAOCreatorMock = new Mock<DAOCreator<Student>>();
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object);
            var sortField = typeof(ExamResult).GetProperty("Student");
            //Act
            reportManager.SaveSessionResults(sessionName, filePath, sortField);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessionResultsSummary_ValidData_ShouldSaveSessionSummatyTable(List<ExamResult> examResults)
        {
            //Arrange
            string filePath = @"..\..\..\TestFiles\SessionResultSummary.xlsx";
            string testFilePath = @"..\..\..\TestFiles\TestSessionResultSummary.xlsx";
            string sessionName = "Session1";
            var examDAOCreatorMock = new Mock<DAOCreator<Exam>>();
            var examResultDAOCreatorMock = new Mock<DAOCreator<ExamResult>>();
            var groupDAOCreatorMock = new Mock<DAOCreator<Group>>();
            var sessionDAOCreatorMock = new Mock<DAOCreator<Session>>();
            var studentDAOCreatorMock = new Mock<DAOCreator<Student>>();
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object);
            //Act
            reportManager.SaveSessionResultsSummary(sessionName, filePath, null);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessionResultsSummary_ValidDataAverageFieldSort_ShouldSaveSessionSummatyTableSorted(List<ExamResult> examResults)
        {
            //Arrange
            string filePath = @"..\..\..\TestFiles\SessionResultSummaryAvarageSorted.xlsx";
            string testFilePath = @"..\..\..\TestFiles\TestSessionResultSummaryAvarageSorted.xlsx";
            string sessionName = "Session1";
            var examDAOCreatorMock = new Mock<DAOCreator<Exam>>();
            var examResultDAOCreatorMock = new Mock<DAOCreator<ExamResult>>();
            var groupDAOCreatorMock = new Mock<DAOCreator<Group>>();
            var sessionDAOCreatorMock = new Mock<DAOCreator<Session>>();
            var studentDAOCreatorMock = new Mock<DAOCreator<Student>>();
            var sortField = typeof(SessionGroupSummary).GetProperty("AverageGrade");
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object);
            //Act
            reportManager.SaveSessionResultsSummary(sessionName, filePath, sortField);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessionResultsSummary_ValidDataMinimumFieldSort_ShouldSaveSessionSummatyTableSorted(List<ExamResult> examResults)
        {
            //Arrange
            string filePath = @"..\..\..\TestFiles\SessionResultSummaryMinimumSorted.xlsx";
            string testFilePath = @"..\..\..\TestFiles\TestSessionResultSummaryMinimumSorted.xlsx";
            string sessionName = "Session1";
            var examDAOCreatorMock = new Mock<DAOCreator<Exam>>();
            var examResultDAOCreatorMock = new Mock<DAOCreator<ExamResult>>();
            var groupDAOCreatorMock = new Mock<DAOCreator<Group>>();
            var sessionDAOCreatorMock = new Mock<DAOCreator<Session>>();
            var studentDAOCreatorMock = new Mock<DAOCreator<Student>>();
            var sortField = typeof(SessionGroupSummary).GetProperty("MinGrade");
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object);
            //Act
            reportManager.SaveSessionResultsSummary(sessionName, filePath, sortField);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessionResultsSummary_ValidDataMaximumFieldSort_ShouldSaveSessionSummatySortedTableSorted(List<ExamResult> examResults)
        {
            //Arrange
            string filePath = @"..\..\..\TestFiles\SessionResultSummaryMaximumSorted.xlsx";
            string testFilePath = @"..\..\..\TestFiles\TestSessionResultSummaryMaximumSorted.xlsx";
            string sessionName = "Session1";
            var examDAOCreatorMock = new Mock<DAOCreator<Exam>>();
            var examResultDAOCreatorMock = new Mock<DAOCreator<ExamResult>>();
            var groupDAOCreatorMock = new Mock<DAOCreator<Group>>();
            var sessionDAOCreatorMock = new Mock<DAOCreator<Session>>();
            var studentDAOCreatorMock = new Mock<DAOCreator<Student>>();
            var sortField = typeof(SessionGroupSummary).GetProperty("MaxGrade");
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object);
            //Act
            reportManager.SaveSessionResultsSummary(sessionName, filePath, sortField);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void GetStudentToExpel_ValidData_ShouldReturnStudentsList(List<ExamResult> examResults)
        {
            //Arrange
            string sessionName = "Session1";
            List<Student> testStudents = new List<Student> { _students[1], _students[2] };
            var examDAOCreatorMock = new Mock<DAOCreator<Exam>>();
            var examResultDAOCreatorMock = new Mock<DAOCreator<ExamResult>>();
            var groupDAOCreatorMock = new Mock<DAOCreator<Group>>();
            var sessionDAOCreatorMock = new Mock<DAOCreator<Session>>();
            var studentDAOCreatorMock = new Mock<DAOCreator<Student>>();
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object);
            //Act
            var resultStudents = reportManager.GetStudentToExpel(sessionName, null);
            //Assert
            Assert.IsTrue(testStudents.SequenceEqual(resultStudents));
        }
    }
}
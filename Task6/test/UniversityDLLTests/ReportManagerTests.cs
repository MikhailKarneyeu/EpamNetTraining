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
                new Session(1, "Session1", Convert.ToDateTime("24.05.2019"), Convert.ToDateTime("07.06.2019")),
                new Session(2, "Session2", Convert.ToDateTime("23.12.2019"), Convert.ToDateTime("06.01.2020")),
            };

        private static readonly List<Exam> _exams =
            new List<Exam>
            {
                new Exam(1, 1, 1, Convert.ToDateTime("25.05.2019 08:00:00")),
                new Exam(2, 1, 2, Convert.ToDateTime("28.05.2019 08:00:00")),
                new Exam(3, 1, 3, Convert.ToDateTime("30.05.2019 08:00:00")),
                new Exam(4, 2, 4, Convert.ToDateTime("24.12.2019 08:00:00")),

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
                new Student(1, 1, "Student1", "Female", Convert.ToDateTime("12.02.2000")),
                new Student(2, 1, "Student2", "Male", Convert.ToDateTime("14.08.2000")),
                new Student(3, 2, "Student3", "Male", Convert.ToDateTime("09.03.2000")),
                new Student(4, 2, "Student4", "Male", Convert.ToDateTime("15.04.2001")),
                new Student(5, 3, "Student5", "Male", Convert.ToDateTime("03.03.2000"))
            };

        private static readonly List<Subject> _subjects =
            new List<Subject>
            {
                new Subject(1, "Subject1"),
                new Subject(2, "Subject2"),
                new Subject(3, "Subject3"),
                new Subject(4, "Subject4")
            };

        private static readonly object[] _examResultsLists =
        {
            new object[]
            {
                new List<ExamResult>
                {
                    new ExamResult(1, 1, 1, "8"),
                    new ExamResult(2, 1, 2, "3"),
                    new ExamResult(3, 1, 3, "2"),
                    new ExamResult(4, 1, 4, "7"),
                    new ExamResult(5, 1, 5, "9"),
                    new ExamResult(6, 2, 1, "7"),
                    new ExamResult(7, 2, 2, "2"),
                    new ExamResult(8, 2, 3, "3"),
                    new ExamResult(9, 2, 4, "7"),
                    new ExamResult(10, 2, 5, "9"),
                    new ExamResult(11, 3, 1, "7"),
                    new ExamResult(12, 3, 2, "3"),
                    new ExamResult(13, 3, 3, "3"),
                    new ExamResult(14, 3, 4, "2"),
                    new ExamResult(15, 3, 5, "9"),
                    new ExamResult(16, 4, 1, "7"),
                    new ExamResult(17, 4, 2, "9"),
                    new ExamResult(18, 4, 3, "2"),
                    new ExamResult(19, 4, 4, "7"),
                    new ExamResult(20, 4, 5, "8")
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
            var subjectDAOCreatorMock = new Mock<DAOCreator<Subject>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object);
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
            var subjectDAOCreatorMock = new Mock<DAOCreator<Subject>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object);
            var sortField = typeof(SessionResult).GetProperty("StudentName");
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
            var subjectDAOCreatorMock = new Mock<DAOCreator<Subject>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object);
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
            var subjectDAOCreatorMock = new Mock<DAOCreator<Subject>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object);
            var sortField = typeof(SessionGroupSummary).GetProperty("AverageGrade");
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
            var subjectDAOCreatorMock = new Mock<DAOCreator<Subject>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object); 
            var sortField = typeof(SessionGroupSummary).GetProperty("MinGrade");
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
            var subjectDAOCreatorMock = new Mock<DAOCreator<Subject>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object);
            var sortField = typeof(SessionGroupSummary).GetProperty("MaxGrade");
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
            var subjectDAOCreatorMock = new Mock<DAOCreator<Subject>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object);
            //Act
            var resultStudents = reportManager.GetStudentToExpel(sessionName, null);
            //Assert
            Assert.IsTrue(testStudents.SequenceEqual(resultStudents));
        }
    }
}
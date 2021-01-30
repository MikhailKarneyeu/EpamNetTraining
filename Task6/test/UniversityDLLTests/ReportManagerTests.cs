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
                new Session(1, "Session1", Convert.ToDateTime("24.12.2018"), Convert.ToDateTime("07.01.2019")),
                new Session(2, "Session2", Convert.ToDateTime("24.05.2019"), Convert.ToDateTime("06.06.2019")),
                new Session(3, "Session3", Convert.ToDateTime("24.12.2019"), Convert.ToDateTime("07.01.2020")),
                new Session(4, "Session4", Convert.ToDateTime("24.05.2020"), Convert.ToDateTime("06.06.2020")),
                new Session(5, "Session5", Convert.ToDateTime("24.12.2020"), Convert.ToDateTime("06.01.2021")),
                new Session(6, "Session6", Convert.ToDateTime("24.05.2021"), Convert.ToDateTime("06.06.2021"))
            };

        private static readonly List<Exam> _exams =
            new List<Exam>
            {
                new Exam(1, 1, 1, 1, Convert.ToDateTime("25.12.2018 08:00:00")),
                new Exam(2, 1, 2, 2, Convert.ToDateTime("28.12.2018 08:00:00")),
                new Exam(3, 2, 3, 1, Convert.ToDateTime("25.05.2019 08:00:00")),
                new Exam(4, 2, 4, 2, Convert.ToDateTime("28.05.2019 08:00:00")),
                new Exam(5, 3, 1, 1, Convert.ToDateTime("25.12.2019 08:00:00")),
                new Exam(6, 3, 2, 2, Convert.ToDateTime("28.12.2019 08:00:00")),
                new Exam(7, 4, 3, 1, Convert.ToDateTime("25.05.2020 08:00:00")),
                new Exam(8, 4, 4, 2, Convert.ToDateTime("28.05.2020 08:00:00")),
                new Exam(9, 5, 1, 1, Convert.ToDateTime("25.12.2020 08:00:00")),
                new Exam(10, 5, 2, 2, Convert.ToDateTime("28.12.2020 08:00:00")),
                new Exam(11, 6, 3, 1, Convert.ToDateTime("25.05.2021 08:00:00")),
                new Exam(12, 6, 4, 2, Convert.ToDateTime("28.05.2021 08:00:00"))

            };

        private static readonly List<Group> _groups =
            new List<Group>
            {
                new Group(1, 1, "Group1"),
                new Group(2, 2, "Group2"),
                new Group(3, 2, "Group3")
            };

        private static readonly List<Specialty> _specialties =
            new List<Specialty>
            {
                new Specialty(1, "Specialty1"),
                new Specialty(2, "Specialty2")
            };

        private static readonly List<Student> _students =
            new List<Student>
            {
                new Student(1, 1, "Student1", "Female", Convert.ToDateTime("12.02.2000")),
                new Student(2, 1, "Student2", "Male", Convert.ToDateTime("14.08.2000")),
                new Student(3, 2, "Student3", "Male", Convert.ToDateTime("09.03.2000")),
                new Student(4, 2, "Student4", "Male", Convert.ToDateTime("15.03.2000"))
            };

        private static readonly List<Subject> _subjects =
            new List<Subject>
            {
                new Subject(1, "Subject1"),
                new Subject(2, "Subject2"),
                new Subject(3, "Subject3"),
                new Subject(4, "Subject4")
            };

        private static readonly List<Teacher> _teachers =
            new List<Teacher>
            {
                new Teacher(1, "Teacher1"),
                new Teacher(2, "Teacher2")
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
                    new ExamResult(5, 2, 1, "7"),
                    new ExamResult(6, 2, 2, "2"),
                    new ExamResult(7, 2, 3, "3"),
                    new ExamResult(8, 2, 4, "7"),
                    new ExamResult(9, 3, 1, "7"),
                    new ExamResult(10, 3, 2, "3"),
                    new ExamResult(11, 3, 3, "3"),
                    new ExamResult(12, 3, 4, "2"),
                    new ExamResult(13, 4, 1, "7"),
                    new ExamResult(14, 4, 2, "9"),
                    new ExamResult(15, 4, 3, "2"),
                    new ExamResult(16, 4, 4, "7"),
                    new ExamResult(17, 5, 1, "9"),
                    new ExamResult(18, 5, 2, "6"),
                    new ExamResult(19, 5, 3, "3"),
                    new ExamResult(20, 5, 4, "3"),
                    new ExamResult(21, 6, 1, "3"),
                    new ExamResult(22, 6, 2, "9"),
                    new ExamResult(23, 6, 3, "7"),
                    new ExamResult(24, 6, 4, "8"),
                    new ExamResult(25, 7, 1, "5"),
                    new ExamResult(26, 7, 2, "2"),
                    new ExamResult(27, 7, 3, "8"),
                    new ExamResult(28, 7, 4, "6"),
                    new ExamResult(29, 8, 1, "8"),
                    new ExamResult(30, 8, 2, "3"),
                    new ExamResult(31, 8, 3, "8"),
                    new ExamResult(32, 8, 4, "7"),
                    new ExamResult(33, 9, 1, "8"),
                    new ExamResult(34, 9, 2, "9"),
                    new ExamResult(35, 9, 3, "5"),
                    new ExamResult(36, 9, 4, "2"),
                    new ExamResult(37, 10, 1, "6"),
                    new ExamResult(38, 10, 2, "7"),
                    new ExamResult(39, 10, 3, "8"),
                    new ExamResult(40, 10, 4, "3"),
                    new ExamResult(41, 11, 1, "8"),
                    new ExamResult(42, 11, 2, "7"),
                    new ExamResult(43, 11, 3, "5"),
                    new ExamResult(44, 11, 4, "2"),
                    new ExamResult(45, 12, 1, "7"),
                    new ExamResult(46, 12, 2, "7"),
                    new ExamResult(47, 12, 3, "8"),
                    new ExamResult(48, 12, 4, "3")
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
            var specialtyDAOCreatorMock = new Mock<DAOCreator<Specialty>>();
            var teacherDAOCreatorMock = new Mock<DAOCreator<Teacher>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object, specialtyDAOCreatorMock.Object, teacherDAOCreatorMock.Object);
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
            var specialtyDAOCreatorMock = new Mock<DAOCreator<Specialty>>();
            var teacherDAOCreatorMock = new Mock<DAOCreator<Teacher>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object, specialtyDAOCreatorMock.Object, teacherDAOCreatorMock.Object);
            var sortField = typeof(SessionResult).GetProperty("StudentName");
            //Act
            reportManager.SaveSessionResults(sessionName, filePath, sortField);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessionResultsSummary_ValidData_ShouldSaveSessionSummaryTable(List<ExamResult> examResults)
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
            var specialtyDAOCreatorMock = new Mock<DAOCreator<Specialty>>();
            var teacherDAOCreatorMock = new Mock<DAOCreator<Teacher>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object, specialtyDAOCreatorMock.Object, teacherDAOCreatorMock.Object);
            //Act
            reportManager.SaveSessionResultsSummary(sessionName, filePath, null);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessionResultsSummary_ValidDataAverageFieldSort_ShouldSaveSessionSummaryTableSorted(List<ExamResult> examResults)
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
            var specialtyDAOCreatorMock = new Mock<DAOCreator<Specialty>>();
            var teacherDAOCreatorMock = new Mock<DAOCreator<Teacher>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object, specialtyDAOCreatorMock.Object, teacherDAOCreatorMock.Object);
            var sortField = typeof(SessionGroupSummary).GetProperty("AverageGrade");
            //Act
            reportManager.SaveSessionResultsSummary(sessionName, filePath, sortField);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessionResultsSummary_ValidDataMinimumFieldSort_ShouldSaveSessionSummaryTableSorted(List<ExamResult> examResults)
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
            var specialtyDAOCreatorMock = new Mock<DAOCreator<Specialty>>();
            var teacherDAOCreatorMock = new Mock<DAOCreator<Teacher>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object, specialtyDAOCreatorMock.Object, teacherDAOCreatorMock.Object); 
            var sortField = typeof(SessionGroupSummary).GetProperty("MinGrade");
            //Act
            reportManager.SaveSessionResultsSummary(sessionName, filePath, sortField);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessionResultsSummary_ValidDataMaximumFieldSort_ShouldSaveSessionSummarySortedTableSorted(List<ExamResult> examResults)
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
            var specialtyDAOCreatorMock = new Mock<DAOCreator<Specialty>>();
            var teacherDAOCreatorMock = new Mock<DAOCreator<Teacher>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object, specialtyDAOCreatorMock.Object, teacherDAOCreatorMock.Object);
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
            string sessionName = "Session6";
            List<Student> testStudents = new List<Student> { _students[3] };
            var examDAOCreatorMock = new Mock<DAOCreator<Exam>>();
            var examResultDAOCreatorMock = new Mock<DAOCreator<ExamResult>>();
            var groupDAOCreatorMock = new Mock<DAOCreator<Group>>();
            var sessionDAOCreatorMock = new Mock<DAOCreator<Session>>();
            var studentDAOCreatorMock = new Mock<DAOCreator<Student>>();
            var subjectDAOCreatorMock = new Mock<DAOCreator<Subject>>();
            var specialtyDAOCreatorMock = new Mock<DAOCreator<Specialty>>();
            var teacherDAOCreatorMock = new Mock<DAOCreator<Teacher>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            examResults.Add(new ExamResult(49, 12, 4, "2"));
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object, specialtyDAOCreatorMock.Object, teacherDAOCreatorMock.Object);
            //Act
            var resultStudents = reportManager.GetStudentToExpel(sessionName, null);
            examResults.Remove(new ExamResult(49, 12, 4, "2"));
            //Assert
            Assert.IsTrue(testStudents.SequenceEqual(resultStudents));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessionResultsSpecialtiesSummary_ValidData_ShouldSaveSessionSummary(List<ExamResult> examResults)
        {
            //Arrange
            string filePath = @"..\..\..\TestFiles\SessionResultsSpecialtiesSummary.xlsx";
            string testFilePath = @"..\..\..\TestFiles\TestSessionResultsSpecialtiesSummary.xlsx";
            string sessionName = "Session1";
            var examDAOCreatorMock = new Mock<DAOCreator<Exam>>();
            var examResultDAOCreatorMock = new Mock<DAOCreator<ExamResult>>();
            var groupDAOCreatorMock = new Mock<DAOCreator<Group>>();
            var sessionDAOCreatorMock = new Mock<DAOCreator<Session>>();
            var studentDAOCreatorMock = new Mock<DAOCreator<Student>>();
            var subjectDAOCreatorMock = new Mock<DAOCreator<Subject>>();
            var specialtyDAOCreatorMock = new Mock<DAOCreator<Specialty>>();
            var teacherDAOCreatorMock = new Mock<DAOCreator<Teacher>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            specialtyDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_specialties);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object, specialtyDAOCreatorMock.Object, teacherDAOCreatorMock.Object);
            //Act
            reportManager.SaveSessionResultsSpecialtiesSummary(sessionName, filePath, null);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessionResultsTeacherSummary_ValidData_ShouldSaveSessionSummary(List<ExamResult> examResults)
        {
            //Arrange
            string filePath = @"..\..\..\TestFiles\SessionResultsTeacherSummary.xlsx";
            string testFilePath = @"..\..\..\TestFiles\TestSessionResultsTeacherSummary.xlsx";
            string sessionName = "Session1";
            var examDAOCreatorMock = new Mock<DAOCreator<Exam>>();
            var examResultDAOCreatorMock = new Mock<DAOCreator<ExamResult>>();
            var groupDAOCreatorMock = new Mock<DAOCreator<Group>>();
            var sessionDAOCreatorMock = new Mock<DAOCreator<Session>>();
            var studentDAOCreatorMock = new Mock<DAOCreator<Student>>();
            var subjectDAOCreatorMock = new Mock<DAOCreator<Subject>>();
            var specialtyDAOCreatorMock = new Mock<DAOCreator<Specialty>>();
            var teacherDAOCreatorMock = new Mock<DAOCreator<Teacher>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            teacherDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_teachers);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object, specialtyDAOCreatorMock.Object, teacherDAOCreatorMock.Object);
            //Act
            reportManager.SaveSessionResultsTeacherSummary(sessionName, filePath, null);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }

        [Test, TestCaseSource(nameof(_examResultsLists))]
        public void SaveSessionsSubjectDinamic_ValidData_ShouldSaveSessionsDinamic(List<ExamResult> examResults)
        {
            //Arrange
            string filePath = @"..\..\..\TestFiles\SessionsSubjectDinamic.xlsx";
            string testFilePath = @"..\..\..\TestFiles\TestSessionsSubjectDinamic.xlsx";
            var examDAOCreatorMock = new Mock<DAOCreator<Exam>>();
            var examResultDAOCreatorMock = new Mock<DAOCreator<ExamResult>>();
            var groupDAOCreatorMock = new Mock<DAOCreator<Group>>();
            var sessionDAOCreatorMock = new Mock<DAOCreator<Session>>();
            var studentDAOCreatorMock = new Mock<DAOCreator<Student>>();
            var subjectDAOCreatorMock = new Mock<DAOCreator<Subject>>();
            var specialtyDAOCreatorMock = new Mock<DAOCreator<Specialty>>();
            var teacherDAOCreatorMock = new Mock<DAOCreator<Teacher>>();
            examDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_exams);
            examResultDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(examResults);
            groupDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_groups);
            sessionDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_sessions);
            studentDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_students);
            subjectDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_subjects);
            teacherDAOCreatorMock.Setup(e => e.Create(null).GetAll()).Returns(_teachers);
            ReportManager reportManager = new ReportManager(null, examDAOCreatorMock.Object, examResultDAOCreatorMock.Object, groupDAOCreatorMock.Object, sessionDAOCreatorMock.Object, studentDAOCreatorMock.Object, subjectDAOCreatorMock.Object, specialtyDAOCreatorMock.Object, teacherDAOCreatorMock.Object);
            //Act
            reportManager.SaveSessionsSubjectDinamic(filePath);
            //Assert
            Assert.IsTrue(CompareFiles(filePath, testFilePath));
        }
    }
}
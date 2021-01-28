using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UniversityDAL.Entities;
using UniversityDAL.Services;

namespace UniversityBLL
{
    public class ReportManager
    {
        readonly string _connectionString;
        readonly DAOCreator<Exam> _examDAOCreator;
        readonly DAOCreator<ExamResult> _examResultDAOCreator;
        readonly DAOCreator<Group> _groupDAOCreator;
        readonly DAOCreator<Session> _sessionDAOCreator;
        readonly DAOCreator<Student> _studentDAOCreator;
        readonly DAOCreator<Subject> _subjectDAOCreator;

        public ReportManager()
        { }
        public ReportManager(string connectionString, DAOCreator<Exam> examDAOCreator, DAOCreator<ExamResult> examResultDAOCreator, DAOCreator<Group> groupDAOCreator, DAOCreator<Session> sessionDAOCreator, DAOCreator<Student> studentDAOCreator, DAOCreator<Subject> subjectDAOCreator)
        {
            _connectionString = connectionString;
            _examDAOCreator = examDAOCreator;
            _examResultDAOCreator = examResultDAOCreator;
            _groupDAOCreator = groupDAOCreator;
            _sessionDAOCreator = sessionDAOCreator;
            _studentDAOCreator = studentDAOCreator;
            _subjectDAOCreator = subjectDAOCreator;
        }

        public void SaveSessionResults(string sessionName, string filePath, PropertyInfo sortField)
        {
            if (sortField == null)
                sortField = typeof(SessionResult).GetProperty("ExamName");
            List<ExamResult> examResults = _examResultDAOCreator.Create(_connectionString).GetAll();
            List<Student> students = _studentDAOCreator.Create(_connectionString).GetAll();
            List<Group> groups = _groupDAOCreator.Create(_connectionString).GetAll();
            List<Session> sessions = _sessionDAOCreator.Create(_connectionString).GetAll();
            List<Exam> exams = _examDAOCreator.Create(_connectionString).GetAll();
            List<Subject> subjects = _subjectDAOCreator.Create(_connectionString).GetAll();
            var sessionExamResults = (from e in examResults
                                      join @exam in exams on e.ExamID equals exam.ExamID
                                      join @session in sessions on @exam.SessionID equals session.SessionID
                                      where @session.Name == sessionName
                                      select e).ToList();
            var sessionResults = new List<SessionResult>();
            foreach(ExamResult examResult in sessionExamResults)
            {
                sessionResults.Add(new SessionResult());
                sessionResults[^1].ExamName = subjects.Find(s => s.SubjectID == exams.Find(e => e.ExamID == examResult.ExamID).SubjectID).Name;
                sessionResults[^1].StudentName = students.Find(s => s.StudentID == examResult.StudentID).FullName;
                sessionResults[^1].GroupName = groups.Find(g => g.GroupID == students.Find(s => s.StudentID == examResult.StudentID).GroupID).Name;
                sessionResults[^1].Grade = examResult.Grade;
            }
            sessionResults = (from e in sessionResults
                              orderby sortField.GetValue(e, null)
                              select e).ToList();
            Workbook wb = new Workbook();
            Worksheet sheet = wb.Worksheets[0];
            Cells cells = sheet.Cells;
            Cell cell = cells["A1"];
            cell.PutValue("Exam");
            cell = cells["B1"];
            cell.PutValue("Group");
            cell = cells["C1"];
            cell.PutValue("Student");
            cell = cells["D1"];
            cell.PutValue("Grade");
            int i = 0;
            foreach(SessionResult sessionResult in sessionResults)
            {
                cell = cells[$"A{i+2}"];
                cell.PutValue(sessionResult.ExamName);
                cell = cells[$"B{i+2}"];
                cell.PutValue(sessionResult.GroupName);
                cell = cells[$"C{i+2}"];
                cell.PutValue(sessionResult.StudentName);
                cell = cells[$"D{i+2}"];
                cell.PutValue(sessionResult.Grade);
                i++;
            }
            Aspose.Cells.Tables.ListObject listObject = sheet.ListObjects[sheet.ListObjects.Add("A1", $"D{i+1}", true)];
            wb.Save(filePath, SaveFormat.Xlsx);
        }

        public void SaveSessionResultsSummary(string sessionName, string filePath, PropertyInfo sortField)
        {
            List<ExamResult> examResults = _examResultDAOCreator.Create(_connectionString).GetAll();
            List<Student> students = _studentDAOCreator.Create(_connectionString).GetAll();
            List<Group> groups = _groupDAOCreator.Create(_connectionString).GetAll();
            List<Session> sessions = _sessionDAOCreator.Create(_connectionString).GetAll();
            List<Exam> exams = _examDAOCreator.Create(_connectionString).GetAll();
            var sessionExamResults = (from e in examResults
                                      join @exam in exams on e.ExamID equals exam.ExamID
                                      join @session in sessions on @exam.SessionID equals session.SessionID
                                      where @session.Name == sessionName
                                      select e).ToList();
            var sessionResults = new List<SessionResult>();
            foreach (ExamResult examResult in sessionExamResults)
            {
                sessionResults.Add(new SessionResult());
                sessionResults[^1].GroupName = groups.Find(g => g.GroupID == students.Find(s => s.StudentID == examResult.StudentID).GroupID).Name;
                sessionResults[^1].Grade = examResult.Grade;
            }
            var sessionGroups = from e in sessionResults
                                group e by e.GroupName;
            List<SessionGroupSummary> sessionSummaries = new List<SessionGroupSummary>();
            foreach (IGrouping<string, SessionResult> g in sessionGroups)
            {
                sessionSummaries.Add(new SessionGroupSummary());
                sessionSummaries[^1].GroupName = g.Key;
                sessionSummaries[^1].AverageGrade = g.Average(e => Convert.ToInt32(e.Grade));
                sessionSummaries[^1].MaxGrade = g.Max(e => Convert.ToInt32(e.Grade));
                sessionSummaries[^1].MinGrade = g.Min(e => Convert.ToInt32(e.Grade));
            }
            if(sortField == null)
                sortField = typeof(SessionGroupSummary).GetProperty("GroupName");
            sessionSummaries = (from e in sessionSummaries
                                orderby sortField.GetValue(e, null)
                                select e).ToList();
            Workbook wb = new Workbook();
            Worksheet sheet = wb.Worksheets[0];
            Cells cells = sheet.Cells;
            Cell cell = cells["A1"];
            cell.PutValue("Group");
            cell = cells["B1"];
            cell.PutValue("Average grade");
            cell = cells["C1"];
            cell.PutValue("Minimal grade");
            cell = cells["D1"];
            cell.PutValue("Maximal grade");
            int i = 0;
            foreach (SessionGroupSummary sessionSummary in sessionSummaries)
            {
                cell = cells[$"A{i + 2}"];
                cell.PutValue(sessionSummary.GroupName);
                cell = cells[$"B{i + 2}"];
                cell.PutValue(sessionSummary.AverageGrade);
                cell = cells[$"C{i + 2}"];
                cell.PutValue(sessionSummary.MinGrade);
                cell = cells[$"D{i + 2}"];
                cell.PutValue(sessionSummary.MaxGrade);
                i++;
            }
            Aspose.Cells.Tables.ListObject listObject = sheet.ListObjects[sheet.ListObjects.Add("A1", $"D{i + 1}", true)];
            wb.Save(filePath, SaveFormat.Xlsx);
        }

        public List<Student> GetStudentToExpel(string sessionName, PropertyInfo sortField)
        {
            List<Student> resultList = new List<Student>();
            List<ExamResult> examResults = _examResultDAOCreator.Create(_connectionString).GetAll();
            List<Student> students = _studentDAOCreator.Create(_connectionString).GetAll();
            List<Group> groups = _groupDAOCreator.Create(_connectionString).GetAll();
            List<Session> sessions = _sessionDAOCreator.Create(_connectionString).GetAll();
            List<Exam> exams = _examDAOCreator.Create(_connectionString).GetAll();
            List<Subject> subjects = _subjectDAOCreator.Create(_connectionString).GetAll();
            var sessionExamResults = (from e in examResults
                                      join @exam in exams on e.ExamID equals exam.ExamID
                                      join @session in sessions on @exam.SessionID equals session.SessionID
                                      where @session.Name == sessionName
                                      select e).ToList();
            var examsByStudent = from e in examResults
                                group e by e.StudentID;
            foreach(IGrouping<int, ExamResult> g in examsByStudent)
            {
                int failTestsCount = g.Count(e => Convert.ToInt32(e.Grade) < 4);
                if (failTestsCount > 2)
                    resultList.Add(students.Find(s => s.StudentID == g.Key));
            }
            if(sortField == null)
                sortField = typeof(Student).GetProperty("FullName");
            resultList = (from e in resultList
                          orderby sortField.GetValue(e, null)
                          select e).ToList();
            return resultList;
        }
    }
}

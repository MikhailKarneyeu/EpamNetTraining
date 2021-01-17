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

        public ReportManager()
        { }
        public ReportManager(string connectionString, DAOCreator<Exam> examDAOCreator, DAOCreator<ExamResult> examResultDAOCreator, DAOCreator<Group> groupDAOCreator, DAOCreator<Session> sessionDAOCreator, DAOCreator<Student> studentDAOCreator)
        {
            _connectionString = connectionString;
            _examDAOCreator = examDAOCreator;
            _examResultDAOCreator = examResultDAOCreator;
            _groupDAOCreator = groupDAOCreator;
            _sessionDAOCreator = sessionDAOCreator;
            _studentDAOCreator = studentDAOCreator;
        }

        public void SaveSessionResults(string sessionName, string filePath, PropertyInfo sortField)
        {
            if (sortField == null)
                sortField = typeof(ExamResult).GetProperty("Exam");
            List<ExamResult> examResults = _examResultDAOCreator.Create(_connectionString).GetAll();
            var examSortedResults = from e in examResults
                                    where e.Exam.Session.Name.Equals(sessionName)
                                    orderby sortField.GetValue(e, null)
                                    select e;
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
            foreach(ExamResult examResult in examSortedResults)
            {
                cell = cells[$"A{i+2}"];
                cell.PutValue(examResult.Exam.Name);
                cell = cells[$"B{i+2}"];
                cell.PutValue(examResult.Student.Group.Name);
                cell = cells[$"C{i+2}"];
                cell.PutValue(examResult.Student.FullName);
                cell = cells[$"D{i+2}"];
                cell.PutValue(examResult.Grade);
                i++;
            }
            Aspose.Cells.Tables.ListObject listObject = sheet.ListObjects[sheet.ListObjects.Add("A1", $"D{i+1}", true)];
            wb.Save(filePath, SaveFormat.Xlsx);
        }

        public void SaveSessionResultsSummary(string sessionName, string filePath, PropertyInfo sortField)
        {
            List<ExamResult> examResults = _examResultDAOCreator.Create(_connectionString).GetAll();
            examResults = (from e in examResults
                          where e.Exam.Session.Name.Equals(sessionName)
                          select e).ToList();
            var sessionGroups = from e in examResults
                                group e by e.Student.Group;
            List<SessionGroupSummary> sessionSummaries = new List<SessionGroupSummary>();
            foreach (IGrouping<Group, ExamResult> g in sessionGroups)
            {
                sessionSummaries.Add(new SessionGroupSummary());
                sessionSummaries[^1].Group = g.Key;
                sessionSummaries[^1].AverageGrade = g.Average(e => Convert.ToInt32(e.Grade));
                sessionSummaries[^1].MaxGrade = g.Max(e => Convert.ToInt32(e.Grade));
                sessionSummaries[^1].MinGrade = g.Min(e => Convert.ToInt32(e.Grade));
            }
            if(sortField == null)
                sortField = typeof(SessionGroupSummary).GetProperty("Group");
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
                cell.PutValue(sessionSummary.Group.Name);
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
            examResults = (from e in examResults
                           where e.Exam.Session.Name.Equals(sessionName)
                           select e).ToList();
            var examsByStudent = from e in examResults
                                group e by e.Student;
            foreach(IGrouping<Student, ExamResult> g in examsByStudent)
            {
                int failTestsCount = g.Count(e => Convert.ToInt32(e.Grade) < 4);
                if (failTestsCount > 2)
                    resultList.Add(g.Key);
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

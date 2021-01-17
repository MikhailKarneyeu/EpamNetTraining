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
        readonly IDAO<Exam> _examDao;
        readonly IDAO<ExamResult> _examResultDao;
        readonly IDAO<Group> _groupDao;
        readonly IDAO<Session> _sessinDao;
        readonly IDAO<Student> _studentDao;
        
        public ReportManager()
        { }
        public ReportManager(IDAO<Exam> examDao, IDAO<ExamResult> examResultDao, IDAO<Group> groupDao, IDAO<Session> sessinDao, IDAO<Student> studentDao)
        {
            _examDao = examDao;
            _examResultDao = examResultDao;
            _groupDao = groupDao;
            _sessinDao = sessinDao;
            _studentDao = studentDao;
        }

        public void SaveSessinResults(string sessionName, string filePath, FieldInfo sortField)
        {
            if (sortField == null)
                sortField = typeof(ExamResult).GetField("Exam");
            List<ExamResult> examResults = _examResultDao.GetAll();
            examResults = (List<ExamResult>)(from e in examResults
                                             where e.Exam.Session.Name.Equals(sessionName)
                                             orderby sortField
                                             select e);
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
            foreach(ExamResult examResult in examResults)
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
            listObject.ShowTotals = true;
            wb.Save(filePath, SaveFormat.Xlsx);
        }

        public void SaveSessionResultsSummary(string sessionName, string filePath, FieldInfo sortField)
        {
            List<ExamResult> examResults = _examResultDao.GetAll();
            examResults = (List<ExamResult>)(from e in examResults
                                             where e.Exam.Session.Name.Equals(sessionName)
                                             select e);
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
                sortField = typeof(ExamResult).GetField("Group");
            sessionSummaries = (List<SessionGroupSummary>)(from e in sessionSummaries
                               orderby sortField
                               select e);
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
            listObject.ShowTotals = true;
            wb.Save(filePath, SaveFormat.Xlsx);
        }

        public List<Student> GetStudentToExpel(string sessionName, FieldInfo sortField)
        {
            List<Student> resultList = new List<Student>();
            List<ExamResult> examResults = _examResultDao.GetAll();
            examResults = (List<ExamResult>)(from e in examResults
                                             where e.Exam.Session.Name.Equals(sessionName)
                                             select e);
            var examsByStudent = from e in examResults
                                group e by e.Student;
            foreach(IGrouping<Student, ExamResult> g in examsByStudent)
            {
                int failTestsCount = g.Count(e => Convert.ToInt32(e.Grade) < 4);
                if (failTestsCount > 2)
                    resultList.Add(g.Key);
            }
            if(sortField == null)
                sortField = typeof(Student).GetField("Name");
            resultList = (List<Student>)(from e in resultList
                         orderby sortField
                         select e);
            return resultList;
        }
    }
}

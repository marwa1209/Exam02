using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class Subject
    {

        #region Properties
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }
        #endregion

        #region Constructor
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        #endregion

        #region Methods
        public void CreateExam(Exam exam)
        {
            Exam = exam;
        }
        #endregion
    }
}

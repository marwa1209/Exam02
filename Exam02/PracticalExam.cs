using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class PracticalExam : Exam
    {
        #region Constructor
        public PracticalExam(TimeSpan duration, int numberOfQuestions, Subject subject)
            : base(duration, numberOfQuestions, subject) { }
        #endregion

        #region Methods
        public override void ShowExam()
        {
            Console.WriteLine($"Starting Practical Exam for {Subject.SubjectName}");
        }
        #endregion
    }

}

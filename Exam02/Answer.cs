using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class Answer
    {
        #region Properties
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        #endregion

        #region Constructor
        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{AnswerId}. {AnswerText}";
        }
        #endregion
    }
}

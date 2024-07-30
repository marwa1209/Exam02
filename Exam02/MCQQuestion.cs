using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{

    public class MCQQuestion : Question
    {
        #region Constructor
        public MCQQuestion(string header, string body, int mark)
            : base(header, body, mark) { }
        #endregion

        #region Methods
        public override void ShowQuestion()
        {
            Console.WriteLine($"{Body}");
            foreach (var answer in Answers)
            {
                Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
            }
        }
        #endregion
    }
}

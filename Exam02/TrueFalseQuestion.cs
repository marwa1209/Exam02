using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class TrueFalseQuestion : Question
    {
        #region Constructor
        public TrueFalseQuestion(string header, string body, int mark)
            : base(header, body, mark) { }
        #endregion

        #region Methods
        public override void ShowQuestion()
        {
            Console.WriteLine($"{Body}\n1. True\n2. False");
        }
        #endregion
    }
}

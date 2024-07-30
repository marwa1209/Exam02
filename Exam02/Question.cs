using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public abstract class Question
    {
        #region Properties
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> Answers { get; set; }
        public Answer RightAnswer { get; set; }
        #endregion

        #region Constructor
        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = new List<Answer>();
        }
        #endregion

        #region Methods
        public abstract void ShowQuestion();
        #endregion

    }

}

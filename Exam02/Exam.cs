using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public abstract class Exam
    {
        #region Properties
        public TimeSpan Duration { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject Subject { get; set; }
        public List<Question> Questions { get; set; }
        public int TotalMarks { get; private set; }
        #endregion

        #region Constructor
        public Exam(TimeSpan duration, int numberOfQuestions, Subject subject)
        {
            Duration = duration;
            NumberOfQuestions = numberOfQuestions;
            Subject = subject;
            Questions = new List<Question>();
        }
        #endregion

        #region Methods
        public abstract void ShowExam();

        public void StartExam()
        {
            TotalMarks = 0;

            foreach (var question in Questions)
            {
                Console.Clear();
                question.ShowQuestion();
                int userAnswerId = GetUserAnswer();
                if (question.RightAnswer.AnswerId == userAnswerId)
                {
                    Console.WriteLine("Correct!");
                    TotalMarks += question.Mark;
                }
                else
                {
                    Console.WriteLine($"Wrong! The correct answer was: {question.RightAnswer.AnswerText}");
                }
                Console.WriteLine($"Current Total Marks: {TotalMarks}");
                Console.WriteLine("Press Enter to continue to the next question.");
                Console.ReadLine();
            }

            Console.WriteLine($"Final Total Marks: {TotalMarks}");
        }

        private int GetUserAnswer()
        {
            int userAnswerId;
            while (!int.TryParse(Console.ReadLine(), out userAnswerId))
            {
                Console.WriteLine("Invalid input. Please enter a valid answer ID.");
            }
            return userAnswerId;
        }
        #endregion
    }

}

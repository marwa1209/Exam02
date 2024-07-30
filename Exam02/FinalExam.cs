using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class FinalExam : Exam
    {
        #region Constructor
        public FinalExam(TimeSpan duration, int numberOfQuestions, Subject subject)
            : base(duration, numberOfQuestions, subject) { }
        #endregion

        #region Methods
        public override void ShowExam()
        {
            Console.WriteLine($"Starting Final Exam for {Subject.SubjectName}");
            int score = 0;

            foreach (var question in Questions)
            {
                Console.WriteLine(question.Body);
                if (question is MCQQuestion mcqQuestion)
                {
                    foreach (var answer in mcqQuestion.Answers)
                    {
                        Console.WriteLine($"{answer.AnswerId}: {answer.AnswerText}");
                    }

                    Console.Write("Your answer: ");
                    int userAnswer;
                    if (int.TryParse(Console.ReadLine(), out userAnswer) &&
                        mcqQuestion.Answers.Any(a => a.AnswerId == userAnswer))
                    {
                        if (userAnswer == question.RightAnswer.AnswerId)
                        {
                            score += question.Mark;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid answer ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Unsupported question type.");
                }
            }

            Console.WriteLine($"Your score: {score}/{Questions.Count * Questions[0].Mark}");
        }
        #endregion
    }
}

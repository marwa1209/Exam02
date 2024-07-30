using Exam02.Enums;

namespace Exam02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            ExamType examType = ExamType.Final;
            bool examTypeFlag;

            int time;
            bool timeTypeFlag;

            int numberOfQuestions;
            bool numberOfQuestionsFlag;

            QuestionType questionType = QuestionType.MSQ;
            bool questionTypeFlag;

            #region ExamType
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("EXAM TYPE ");
            Console.ForegroundColor = originalColor;
            Console.Write("Enter the exam type (0 for Final, 1 for Practical): ");
            do
            {
                int examTypeInt;
                examTypeFlag = int.TryParse(Console.ReadLine(), out examTypeInt);
                if (!examTypeFlag || !Enum.IsDefined(typeof(ExamType), examTypeInt))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer (0 for Final, 1 for Practical): ");
                    examTypeFlag = false;
                }
                else
                {
                    examType = (ExamType)examTypeInt;
                }
            } while (!examTypeFlag);
            #endregion

            #region ExamTime
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("************************************ ");
            Console.WriteLine("EXAM TIME");
            Console.ForegroundColor = originalColor;
            Console.WriteLine($"Please Enter the time for your {examType} exam (30 min to 180 min): ");
            do
            {
                timeTypeFlag = int.TryParse(Console.ReadLine(), out time);
                if (!timeTypeFlag)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
                else if (time < 30 || time > 180)
                {
                    Console.WriteLine("Invalid input. Please enter a time between 30 and 180 minutes.");
                    timeTypeFlag = false;
                }
            } while (!timeTypeFlag);
            #endregion

            #region NumberOfQuestions
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("************************************ ");
            Console.WriteLine("NUMBER OF QUESTIONS");
            Console.ForegroundColor = originalColor;
            Console.WriteLine($"Please Enter the number of questions for your {examType} exam");
            do
            {
                numberOfQuestionsFlag = int.TryParse(Console.ReadLine(), out numberOfQuestions);
                if (!numberOfQuestionsFlag)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of questions.");
                }
                else if (numberOfQuestions < 1)
                {
                    Console.WriteLine("Invalid input. Please enter a number of questions greater than zero.");
                    numberOfQuestionsFlag = false;
                }
            } while (!numberOfQuestionsFlag);
            #endregion

            Exam exam = null;
            if (examType == ExamType.Final)
            {
                exam = new FinalExam(TimeSpan.FromMinutes(time), numberOfQuestions, new Subject(1, "Default Subject"));
            }
            else if (examType == ExamType.Practical)
            {
                exam = new PracticalExam(TimeSpan.FromMinutes(time), numberOfQuestions, new Subject(1, "Default Subject"));
            }

            for (int i = 0; i < numberOfQuestions; i++)
            {
                #region QuestionType
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("************************************ ");
                Console.WriteLine("QUESTION TYPE ");
                Console.ForegroundColor = originalColor;
                Console.Write("Enter the Question type (1 for MSQ, 2 for TrueOrFalse): ");
                do
                {
                    int questionTypeInt;
                    questionTypeFlag = int.TryParse(Console.ReadLine(), out questionTypeInt);
                    if (!questionTypeFlag || !Enum.IsDefined(typeof(QuestionType), questionTypeInt))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer (1 for MSQ, 2 for TrueOrFalse): ");
                        questionTypeFlag = false;
                    }
                    else
                    {
                        questionType = (QuestionType)questionTypeInt;
                    }
                } while (!questionTypeFlag);

                Question question = null;
                if (questionType == QuestionType.MSQ)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("************************************ ");
                    Console.WriteLine("MSQ QUESTION");
                    Console.ForegroundColor = originalColor;
                    Console.Write("Enter the question body: ");
                    string body = Console.ReadLine();
                    Console.Write("Enter the mark for this question: ");
                    int mark;
                    while (!int.TryParse(Console.ReadLine(), out mark) || mark < 1)
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number for the mark.");
                    }

                    question = new MCQQuestion("Header", body, mark);

                    for (int j = 1; j <= 3; j++)
                    {
                        Console.Write($"Enter choice {j}: ");
                        string choice = Console.ReadLine();
                        ((MCQQuestion)question).Answers.Add(new Answer(j, choice));
                    }

                    Console.Write("Enter the correct answer ID: ");
                    int answerId;
                    while (!int.TryParse(Console.ReadLine(), out answerId) || !((MCQQuestion)question).Answers.Any(a => a.AnswerId == answerId))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid answer ID.");
                    }
                    question.RightAnswer = ((MCQQuestion)question).Answers.Find(a => a.AnswerId == answerId);
                }
                else if (questionType == QuestionType.TrueOrFalse)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("************************************ ");
                    Console.WriteLine("TRUE OR FALSE QUESTION");
                    Console.ForegroundColor = originalColor;
                    Console.Write("Enter the question body: ");
                    string body = Console.ReadLine();
                    Console.Write("Enter the mark for this question: ");
                    int mark;
                    while (!int.TryParse(Console.ReadLine(), out mark) || mark < 1)
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number for the mark.");
                    }

                    question = new TrueFalseQuestion("Header", body, mark);

                    Console.WriteLine("Enter the correct answer (1 for True, 2 for False): ");
                    int answerId;
                    while (!int.TryParse(Console.ReadLine(), out answerId) || (answerId != 1 && answerId != 2))
                    {
                        Console.WriteLine("Invalid input. Please enter 1 for True or 2 for False.");
                    }
                    question.RightAnswer = new Answer(answerId, answerId == 1 ? "True" : "False");
                }
                #endregion

                exam.Questions.Add(question);
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("************************************ ");
            Console.WriteLine("DO YOU WANT TO START THE EXAM? (Y/N)");
            Console.ForegroundColor = originalColor;
            char startExam = Console.ReadKey().KeyChar;
            if (startExam == 'Y' || startExam == 'y')
            {
                Console.Clear();
                exam.ShowExam();
                exam.StartExam();
            }
            else
            {
                Console.WriteLine("\nExam not started.");
            }
        }
    }
}

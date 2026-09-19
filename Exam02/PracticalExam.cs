using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class PracticalExam:Exam
    {
        public override void ShowExam()
        {
            if (Questions == null || Questions.Length == 0)
            {
                Console.WriteLine("No questions available for this exam.");
                return;
            }

            Console.WriteLine("---- Practical Exam ----");

            foreach (Question question in Questions)
            {
                Console.WriteLine($"\nQuestion: {question.Header}");
                Console.WriteLine(question.Body);

                if (question.AnswerList != null)
                {
                    foreach (Answer answer in question.AnswerList)
                    {
                        Console.WriteLine($"- {answer.AnswerText}");
                    }
                }

                Console.Write("Your answer: ");
                string? userAnswer = Console.ReadLine();
            }

            Console.WriteLine("\n---- Correct Answers ----");
            foreach (Question question in Questions)
            {
                Console.WriteLine($"{question.Header}: {question.CorrectAnswer?.AnswerText}");
            }
        }
    }
}
    


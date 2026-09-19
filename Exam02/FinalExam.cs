using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public  class FinalExam:Exam
    {
        public override void ShowExam()
        {
            if (Questions == null || Questions.Length == 0)
            {
                Console.WriteLine("No questions available for this exam.");
                return;
            }

            int totalGrade = 0;

            Console.WriteLine("---- Final Exam ----");

            foreach (Question question in Questions)
            {
                Console.WriteLine($"\nQuestion: {question.Header}");
                Console.WriteLine(question.Body);

           
                if (question.AnswerList != null)
                {
                    for (int i = 0; i < question.AnswerList.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {question.AnswerList[i].AnswerText}");
                    }
                }

                Console.Write("Your answer (enter number): ");
                string? userChoice = Console.ReadLine();

                
                Answer? selectedAnswer = null;
                if (int.TryParse(userChoice, out int choiceIndex) &&
                    question.AnswerList != null &&
                    choiceIndex >= 1 && choiceIndex <= question.AnswerList.Length)
                {
                    selectedAnswer = question.AnswerList[choiceIndex - 1];
                }

                if (selectedAnswer != null && question.CorrectAnswer != null &&
                    selectedAnswer.AnswerId == question.CorrectAnswer.AnswerId)
                {
                    totalGrade += question.Mark;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Wrong! Correct answer: {question.CorrectAnswer?.AnswerText}");
                }
            }

            Console.WriteLine($"\nTotal Grade: {totalGrade}");
        }
    }

}

      


        
    



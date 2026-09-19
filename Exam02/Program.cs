// See https://aka.ms/new-console-template for more information
using Exam02;
using System.Security.Cryptography.X509Certificates;


//if (Questions == null || Questions.Length == 0)
//{
//    Console.WriteLine("No questions available for this exam.");
//    return;
//}

//int totalGrade = 0;

//Console.WriteLine("---- Final Exam ----");

//foreach (Question question in Questions)
//{
//    Console.WriteLine($"\nQuestion: {question.Header}");
//    Console.WriteLine(question.Body);


Console.WriteLine("Choose Exam Type:");
Console.WriteLine("1. Final Exam");
Console.WriteLine("2. Practical Exam");
Console.Write("Enter your choice (1 or 2): ");
string? choice = Console.ReadLine();

while (choice != "1" && choice != "2")
{
    Console.Write("Invalid choice. Please enter 1 or 2: ");
    choice = Console.ReadLine();
}

string examType = choice == "1" ? "Final" : "Practical";

int examTime = 0;
bool validTime = false;

while (!validTime)
{
    Console.Write("Enter Exam Time (in minutes, between 10 and 180): ");
    string? timeInput = Console.ReadLine();

    if (int.TryParse(timeInput, out examTime) && examTime >= 10 && examTime <= 180)
    {
        validTime = true;
    }
    else
    {
        Console.WriteLine("Invalid time! Please enter a number between 10 and 180.");
    }
}

List<Question> questionsList = new List<Question>();

bool addMore = true;
while (addMore)
{
    Console.WriteLine("\n---- Add New Question ----");
    Console.Write("Enter Question Header: ");
    string header = Console.ReadLine() ?? "";

    Console.Write("Enter Question Body: ");
    string body = Console.ReadLine() ?? "";

    Console.Write("Enter Mark: ");
    int mark = int.Parse(Console.ReadLine() ?? "0");

    string questionType;
    if (examType == "Final")
    {
        Console.Write("Question Type (1: True/False, 2: MCQ): ");
        string? typeChoice = Console.ReadLine();
        questionType = typeChoice == "1" ? "TrueFalse" : "MCQ";
    }
    else
    {
        questionType = "MCQ";
    }

    List<Answer> answers = new List<Answer>();
    Console.Write("How many answers/choices? ");
    int answerCount = int.Parse(Console.ReadLine() ?? "2");

    for (int i = 0; i < answerCount; i++)
    {
        Console.Write($"Enter answer {i + 1}: ");
        string answerText = Console.ReadLine() ?? "";
        answers.Add(new Answer { AnswerId = i + 1, AnswerText = answerText });
    }

    Console.Write("Enter the number of the correct answer: ");
    int correctIndex = int.Parse(Console.ReadLine() ?? "1");
    Answer correctAnswer = answers[correctIndex - 1];

    Question newQuestion;
    if (questionType == "MCQ")
    {
        newQuestion = new MCQQuestion
        {
            Header = header,
            Body = body,
            Mark = mark,
            AnswerList = answers.ToArray(),
            CorrectAnswer = correctAnswer
        };
    }
    else
    {
        newQuestion = new TrueFalseQuestion
        {
            Header = header,
            Body = body,
            Mark = mark,
            AnswerList = answers.ToArray(),
            CorrectAnswer = correctAnswer
        };
    }

    questionsList.Add(newQuestion);

    Console.Write("\nAdd another question? (y/n): ");
    string? more = Console.ReadLine();
    addMore = more?.ToLower() == "y";
}

Subject math = new Subject { SubjectId = 1, SubjectName = "General Knowledge" };
Exam myExam = math.CreateExam(examType);
myExam.Time = examTime;
myExam.NumberOfQuestion = questionsList.Count;
myExam.Questions = questionsList.ToArray();

Console.WriteLine("\nPress Enter to Start the Exam...");
Console.ReadLine();

myExam.ShowExam();


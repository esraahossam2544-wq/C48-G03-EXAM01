using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public  class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public  Exam CreateExam(string examType)
        {
            if (examType == "Final")
                Exam = new FinalExam();
            else
                Exam = new PracticalExam();
            return Exam;

        }
       

    }
}

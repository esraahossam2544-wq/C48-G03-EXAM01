using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestion { get; set; }
        public Question[]?Questions { get; set; }
        public abstract void ShowExam();
        

        
    }
}

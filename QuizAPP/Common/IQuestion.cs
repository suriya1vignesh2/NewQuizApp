using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAPP.Model
{
    public interface IQuestion
    {
        int QuestionNumber { get; set; }
        string QuestionContent { get; set; }
       // string Answer { get; set;}
        
    }
}

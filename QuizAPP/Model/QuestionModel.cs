using QuizAPP.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAPP.Model
{
    public class QuestionModel 
    {
        public QuestionModel(  )
        {

        }
        public QuestionTypes QuestionType { get; set; }
        public IQuestion Question { get; set; }

        public bool IsAnswered { get; set; }

        public double AnswerAccuracy { get; set; }

        public string CorrectAnswer { get; set; }
    }
}

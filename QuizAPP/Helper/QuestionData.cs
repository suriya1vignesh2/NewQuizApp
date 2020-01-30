using QuizAPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAPP.Helper
{
    public static class QuestionData
    {
        public static List<QuestionModel> GetQuestions()
        {
            List<QuestionModel> list = new List<QuestionModel>();
            QuestionModel question1 = new QuestionModel();
            MultipleChoiceQuestion mcq1 = new MultipleChoiceQuestion();
            mcq1.QuestionContent = "How many months do we have in a year?";
            mcq1.Options = new List<Option>() { new Option() { OptionNumber = "1", AnswerContent = "12" }, new Option() { OptionNumber = "2", AnswerContent = "11" }, new Option() { OptionNumber = "3", AnswerContent = "10" }, new Option() { OptionNumber = "4", AnswerContent = "15" } };
            question1.Question = mcq1;
            question1.CorrectAnswer = "12";
            question1.QuestionType = QuestionTypes.SingleAnswerTypeQuestions;
            list.Add(question1);
            QuestionModel question2 = new QuestionModel();
            MultipleChoiceQuestion mcq2 = new MultipleChoiceQuestion();
            mcq2.QuestionContent = "How many days do we have in a week?";
            mcq2.Options = new List<Option>() { new Option() { OptionNumber = "1", AnswerContent = "12" }, new Option() { OptionNumber = "2", AnswerContent = "7" }, new Option() { OptionNumber = "3", AnswerContent = "10" }, new Option() { OptionNumber = "4", AnswerContent = "15" } };
            question2.Question = mcq2;
            question2.CorrectAnswer = "7";
            question2.QuestionType = QuestionTypes.SingleAnswerTypeQuestions;
            list.Add(question2);

            QuestionModel question3 = new QuestionModel();
            MultipleChoiceQuestion mcq3 = new MultipleChoiceQuestion();
            mcq3.QuestionContent = "How many days are there in a year?";
            mcq3.Options = new List<Option>() { new Option() { OptionNumber = "1", AnswerContent = "125" }, new Option() { OptionNumber = "2", AnswerContent = "117" }, new Option() { OptionNumber = "3", AnswerContent = "365" }, new Option() { OptionNumber = "4", AnswerContent = "150" } };
            question3.Question = mcq3;
            question3.CorrectAnswer = "365";
            question3.QuestionType = QuestionTypes.SingleAnswerTypeQuestions;
            list.Add(question3);

            QuestionModel question4 = new QuestionModel();
            MultipleChoiceQuestion mcq4 = new MultipleChoiceQuestion();
            mcq4.QuestionContent = "What is 2+2?";
            mcq4.Options = new List<Option>() { new Option() { OptionNumber = "1", AnswerContent = "4" }, new Option() { OptionNumber = "2", AnswerContent = "7" }, new Option() { OptionNumber = "3", AnswerContent = "5" }, new Option() { OptionNumber = "4", AnswerContent = "1" } };
            question4.Question = mcq4;
            question4.CorrectAnswer = "4";
            question4.QuestionType = QuestionTypes.SingleAnswerTypeQuestions;
            list.Add(question4);

            QuestionModel question5 = new QuestionModel();
            MultipleChoiceQuestion mcq5 = new MultipleChoiceQuestion();
            mcq5.QuestionContent = "How many colors are there in a rainbow?";
            mcq5.Options = new List<Option>() { new Option() { OptionNumber = "1", AnswerContent = "12" }, new Option() { OptionNumber = "2", AnswerContent = "7" }, new Option() { OptionNumber = "3", AnswerContent = "90" }, new Option() { OptionNumber = "4", AnswerContent = "195" } };
            question5.Question = mcq5;
            question5.CorrectAnswer = "7";
            question5.QuestionType = QuestionTypes.SingleAnswerTypeQuestions;
            list.Add(question5);

            QuestionModel question6 = new QuestionModel();
            MultipleChoiceQuestion mcq6 = new MultipleChoiceQuestion();
            mcq6.QuestionContent = "Select All Indian Languages";
            mcq6.Options = new List<Option>() { new Option() { OptionNumber = "1", AnswerContent = "Tamil" }, new Option() { OptionNumber = "2", AnswerContent = "English" }, new Option() { OptionNumber = "3", AnswerContent = "French" }, new Option() { OptionNumber = "4", AnswerContent = "Telugu" } };
            question6.Question = mcq6;
            question6.QuestionType = QuestionTypes.MultipleAnswersTypeQuestions;
            question6.CorrectAnswer = "Tamil,Telugu";
            list.Add(question6);

            QuestionModel question7 = new QuestionModel();
            MultipleChoiceQuestion mcq7 = new MultipleChoiceQuestion();
            mcq7.QuestionContent = "Select All Indian festivals ";
            mcq7.Options = new List<Option>() { new Option() { OptionNumber = "1", AnswerContent = "Depavali" }, new Option() { OptionNumber = "2", AnswerContent = "Christmas" }, new Option() { OptionNumber = "3", AnswerContent = "GaneshChadurthi" }, new Option() { OptionNumber = "4", AnswerContent = "Hollowenday" } };
            question7.Question = mcq7;
            question7.QuestionType = QuestionTypes.MultipleAnswersTypeQuestions;
            question7.CorrectAnswer = "Depavali,GaneshChadurthi";
            list.Add(question7);

            QuestionModel question8 = new QuestionModel();
            MultipleChoiceQuestion mcq8 = new MultipleChoiceQuestion();
            mcq8.QuestionContent = "Select All Numbers";
            mcq8.Options = new List<Option>() { new Option() { OptionNumber = "1", AnswerContent = "1" }, new Option() { OptionNumber = "2", AnswerContent = "11" }, new Option() { OptionNumber = "3", AnswerContent = "Holiday" } };
            question8.Question = mcq8;
            question8.CorrectAnswer = "1,11";
            question8.QuestionType = QuestionTypes.MultipleAnswersTypeQuestions;
            list.Add(question8);

            QuestionModel question9 = new QuestionModel();
            MultipleChoiceQuestion mcq9 = new MultipleChoiceQuestion();
            mcq9.QuestionContent = "Select All Vowels";
            mcq9.Options = new List<Option>() { new Option() { OptionNumber = "1", AnswerContent = "K" }, new Option() { OptionNumber = "2", AnswerContent = "A" }, new Option() { OptionNumber = "3", AnswerContent = "E" } , new Option() { OptionNumber = "4", AnswerContent = "L" } , new Option() { OptionNumber = "5", AnswerContent = "U" } };
            question9.Question = mcq9;
            question9.QuestionType = QuestionTypes.MultipleAnswersTypeQuestions;
            list.Add(question9);


            QuestionModel question10 = new QuestionModel();
            MultipleChoiceQuestion mcq10 = new MultipleChoiceQuestion();
            mcq10.QuestionContent = "Select All Indian festivals ";
            mcq10.Options = new List<Option>() { new Option() { OptionNumber = "1", AnswerContent = "Depavali" }, new Option() { OptionNumber = "2", AnswerContent = "Christmas" }, new Option() { OptionNumber = "3", AnswerContent = "GaneshChadurthi" }, new Option() { OptionNumber = "4", AnswerContent = "Hollowenday" } };
            question10.Question = mcq10;
            question10.CorrectAnswer = "Depavali,GaneshChadurthi";
            question10.QuestionType = QuestionTypes.MultipleAnswersTypeQuestions;
            list.Add(question10);

            QuestionModel question11 = new QuestionModel();
            MultipleChoiceQuestion mcq11 = new MultipleChoiceQuestion();
            mcq11.QuestionContent = "Lion is a Wild Animal";
            mcq11.Options = new List<Option>() { new Option() { OptionNumber = "1", AnswerContent = "True" }, new Option() { OptionNumber = "2", AnswerContent = "False" }};
            question11.Question = mcq11;
            question11.CorrectAnswer = "True";
            question11.QuestionType = QuestionTypes.YesORNoTypeQuestions;
            list.Add(question11);

            QuestionModel question12 = new QuestionModel();
            MultipleChoiceQuestion mcq12 = new MultipleChoiceQuestion();
            mcq12.QuestionContent = "Fox is our national animal";
            mcq12.Options = new List<Option>() { new Option() { OptionNumber = "1", AnswerContent = "True" }, new Option() { OptionNumber = "2", AnswerContent = "False" } };
            question12.Question = mcq12;
            question12.CorrectAnswer = "False";
            question12.QuestionType = QuestionTypes.YesORNoTypeQuestions;
            list.Add(question12);
            

            QuestionModel question13 = new QuestionModel();
            EssayTypeQuestion mcq13 = new EssayTypeQuestion();
            mcq13.QuestionContent = "What is 2*3 ?";
            question13.Question = mcq13;
            question13.CorrectAnswer = "6";
            question13.QuestionType = QuestionTypes.EssayTypeQuestions;
            list.Add(question13);
            

            QuestionModel question14= new QuestionModel();
            EssayTypeQuestion mcq14 = new EssayTypeQuestion();
            mcq14.QuestionContent = "What is 23 * 3";
            question14.Question = mcq14;
            question14.CorrectAnswer = "69";
            question14.QuestionType = QuestionTypes.EssayTypeQuestions;
            list.Add(question14);
            

            QuestionModel question15 = new QuestionModel();
            EssayTypeQuestion mcq15 = new EssayTypeQuestion();
            mcq15.QuestionContent = "What is 1+2+3+4 ?";
            question15.Question = mcq15;
            question15.QuestionType = QuestionTypes.EssayTypeQuestions;
            question15.CorrectAnswer = "10";
            list.Add(question15);
            return list;
        }
    }
}

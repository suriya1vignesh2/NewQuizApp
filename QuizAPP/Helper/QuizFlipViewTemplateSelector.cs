using QuizAPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QuizAPP.Helper
{
   public class QuizFlipViewTemplateSelector :DataTemplateSelector
    {
        public DataTemplate EssayTemplate { get; set; }

        public DataTemplate SingleAnswerTemplate { get; set; }

        public DataTemplate MultipleAnswersTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item ==null)
            {
                return null;
            }
            else if(item !=null && item is QuestionModel)
            {
                var model = item as QuestionModel;
                if(model.QuestionType == QuestionTypes.EssayTypeQuestions)
                {
                    return EssayTemplate;
                }
                else if(model.QuestionType == QuestionTypes.MultipleAnswersTypeQuestions )
                {
                    return MultipleAnswersTemplate;
                }
                else if (model.QuestionType == QuestionTypes.SingleAnswerTypeQuestions || model.QuestionType == QuestionTypes.YesORNoTypeQuestions)
                {
                    return SingleAnswerTemplate;
                }
            }

            return new DataTemplate();

                
        }
    }
}


using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ExamDomain.Model
{
    public class ClosedQuestion : Question
    {
        public virtual List<ClosedAnswer> AnswerChoices { get; set; }


        //private int _numberOfAnswers;
        //for display? ViewModel?
        [DefaultValue(1)]
        [Range(1, 10)]
        [Display(Name = "Number of answers")]
        public int NumberOfAnswers
        {
            //get { return AnswerChoices.Count; } 
            //set { _numberOfAnswers = value; }
            get; set; 
        }

    }
}



var myFunction = function() 
{
    $("#NumberOfAnswersTextBox").change(function () {

        var $numberOfAnswers = $("#NumberOfAnswersTextBox").val();

        if ($numberOfAnswers < 1 || $numberOfAnswers > 10) {
            //in MVC validation is done client-side out-of-the-box

            //var validationElement = "<label class=\"text-danger\">" +
            //    "The field Number of answers must be between 1 and 10." +
            //    "</label>";

            //$("#NumberOfAnswersTextBox").append(validationElement);
        }
        else
        {
            //first elements created previously need to be removed
            //RemoveElementsFromPreviousSelection();

            //AppendDivOpeningTags();

            //AppendAnswerTextBoxes();

            //AppendDivClosingTags();

            //$.get('@Url.Action("_ClosedQuestionAnswersPartial", "Questions" )', function (data)
            //{
            //    $('#ClosedAnswersDiv').html(data);
            //});

            //$.load("/Questions/_ClosedQuestionAnswersPartial", function (data)
            //{
            //    $('#ClosedAnswersDiv').html(data);
            //});

           
            //TODO: return the closed question (main) partial view but with different number of answers
            
            $("#ClosedAnswersDiv").load("/Questions/_ClosedQuestionAnswersPartial", { numberOfAnswers: $numberOfAnswers });

        }
    });
}
    


$(document).ready(function ()
{
    
        $("#IsClosedRadioButton").click(function () 
        {
            //TODO: check if there is already a partial view (not so important)
            $("#ClosedQuestionSection").load("/Questions/_ClosedQuestionPartial", myFunction);


            //$("#ClosedQuestionTable").css("visibility", "visible");

            //$.get('@Url.Action("_ClosedQuestionPartial", "Questions", new { questionType = "closed" } )', function (data) {
            //    $('#ClosedQuestionSection').html(data);
            //});

            //var div = "<div id=\"ClosedQuestionPanel\" style=\"visibility: hidden\"></div>";
            //$("#QuestionTypeRadioButtons").append(div);

            return true;
        });

        $("#IsOpenRadioButton").click(function () 
        {
            $("#ClosedQuestionSection").empty();


            //$("#ClosedQuestionTable").css("visibility", "hidden");

            //"visibility: collapse" works only in IE and Firefox
            //in Chrome it's the same as "hidden"
            //$("#ClosedQuestionTable").css("visibility", "collapse");
            return true;
        });
    
});
    

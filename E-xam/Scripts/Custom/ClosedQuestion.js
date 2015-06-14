

$(document).ready(function ()
{

    //If question is of "closed" type, we load
    //a panel that will ask user for answer choices
    $("#IsClosedRadioButton").click(function ()
    {
        //TODO: check if there is already a partial view (not so important)
        $("#ClosedQuestionSection").load("/Questions/_ClosedQuestionPartial", onClosedQuestionViewLoaded);

        return true;
    });

    //If question is of "open" type, the panel for
    //available answer choices is removed
    $("#IsOpenRadioButton").click(function ()
    {
        $("#ClosedQuestionSection").empty();

        return true;
    });

});


var onClosedQuestionViewLoaded = function() 
{
    //If user selected new value for number of answer choices
    $("#NumberOfAnswersTextBox").change(function ()
    {
        var $numberOfAnswers = $("#NumberOfAnswersTextBox").val();

        if ($numberOfAnswers < 1 || $numberOfAnswers > 10)
        {
            //in MVC validation is done client-side out-of-the-box

            //var validationElement = "<label class=\"text-danger\">" +
            //    "The field Number of answers must be between 1 and 10." +
            //    "</label>";

            //$("#NumberOfAnswersTextBox").append(validationElement);
        }
        else
        {
            $("#ClosedAnswersDiv").
                load("/Questions/_ClosedQuestionAnswersPartial", { numberOfAnswers: $numberOfAnswers });
        }
    });
}
    



    

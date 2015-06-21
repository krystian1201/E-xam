

$(document).ready(function ()
{

    //If question is of "closed" type, we load
    //a panel that will ask user for answer choices
    $("#IsClosedRadioButton").click(function ()
    {
        //TODO: check if there is already a partial view (not so important)
        $("#ClosedQuestionSection").load("/Questions/_ClosedQuestionPartial", onClosedQuestionViewLoaded);

        //allow the validation framework to re-parse the DOM
        //jQuery.validator.unobtrusive.parse("#ClosedQuestionSection");

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
    jQuery.validator.unobtrusive.parse("#ClosedQuestionSection");

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
                load("/Questions/_ClosedQuestionAnswersPartial", { numberOfAnswers: $numberOfAnswers },
                jQuery.validator.unobtrusive.parse("#ClosedQuestionSection"));


        }
    });
}
    

function removeNestedForm(element, container, deleteElement)
{
    $container = $(element).parents(container);
    $container.find(deleteElement).val('True');
    $container.hide();
}


function addNestedForm(container, counter, ticks, content)
{
    var nextIndex = $(counter).length;
    var pattern = new RegExp(ticks, "gi");
    content = content.replace(pattern, nextIndex);
    $(container).append(content);
}

//var onClosedAnswersViewLoaded = function ()
//{
//    jQuery.validator.unobtrusive.parse();
//}

    


//function AddCust()
//{
//    var m = $('#divcust input:last-child').attr('name');

//    var index = 0;
//    if (m != null && m.length > 0)
//    {
//        index = m.split('CustList[')[1].replace('].Name', '');
//        index++;
//    }

//    var html = '<label for=\"CustList_' + index + '__Name\">Name</label>' +
//        '<input id=\"CustList_' + index + '__Name\" class=\"text-box single-line\"' +
//        ' type=\"text\" value=\"\" name=\"CustList[' + index + '].Name\">';
//    $('#divcust').append(html);


//};


$(document).ready(function() {
    var lol = $("#NumberOfAnswersTextBox");

    $("#NumberOfAnswersTextBox").onchange = function () {
        var numberOfAnswers = $("#NumberOfAnswersTextBox").val();
    };

    $("#NumberOfAnswersTextBox").change(function () {

        var numberOfAnswers = $("#NumberOfAnswersTextBox").val();

        if (numberOfAnswers < 1 || numberOfAnswers > 10) {
            //in MVC validation is done client-side out-of-the-box

            //var validationElement = "<label class=\"text-danger\">" +
            //    "The field Number of answers must be between 1 and 10." +
            //    "</label>";

            //$("#NumberOfAnswersTextBox").append(validationElement);
        }
        else {
            //first elements created previously need to be removed
            //RemoveElementsFromPreviousSelection();

            //AppendDivOpeningTags();


            ////TODO: MVC field must have a name which matches model field in order to be bound to model? 
            ////TODO: Add "Correct?" radio button

            //AppendAnswerTextBoxes();

            //AppendDivClosingTags();

            //TODO: Add new closed-answer partial view

            $("#ClosedAnswersDiv").load("/Questions/_ClosedQuestionAnswersPartial");
        }


    });
});




function RemoveElementsFromPreviousSelection()
{
    $(".NumberOfAnswersTextBox").remove();
    $(".AnswersBR").remove();
    $("#ClosedAnswersOuterDiv").remove();
}


function AppendDivOpeningTags()
{
    //form-group - outer div
    var outerDivOpen = "<div class=\"form-group\" id=\"ClosedAnswersOuterDiv\">";
    
    $("#NumberOfAnswersDiv").after(outerDivOpen);

    //Answer textboxes - inner div
    var innerDivOpen = "<div id=\"ClosedAnswersInnerDiv\" class=\"col-md-offset-2 col-md-10\">";

    $("#ClosedAnswersOuterDiv").append(innerDivOpen);
}

function AppendAnswerTextBoxes()
{
    //get value of answer choices
    var numberOfAnswers = $("#NumberOfAnswersTextBox").val();

    var textBox = "<input type=\"text\" class=\"NumberOfAnswersTextBox form-control text-box single-line\"/>" +
        "<br class=\"AnswersBR\"/></br class=\"AnswersBR\>";

    //append as many textboxes as needed
    for (var i = 0; i < numberOfAnswers; i++) {
        $("#ClosedAnswersInnerDiv").append(textBox);
    }
}

function AppendDivClosingTags()
{
    var divClose = "</div>";

    $(".NumberOfAnswersTextBox:last-child").append(divClose);
    $(".ClosedAnswersInnerDiv").append(divClose);
}
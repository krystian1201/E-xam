

$(document).ready(function ()
{
    $(function () {
        $("#IsClosedRadioButton").click(function () {
            
            $("#ClosedQuestionPanel").css("visibility", "visible");
            //var div = "<div id=\"ClosedQuestionPanel\" style=\"visibility: hidden\"></div>";
            //$("#QuestionTypeRadioButtons").append(div);

            return true;
        });

        $("#IsOpenRadioButton").click(function () {
            
            $("#ClosedQuestionPanel").css("visibility", "hidden");
            return true;
        });
    });
});
    


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


$('#NumberOfAnswersTextBox').change(function() {

    var textBox = "<input type=\"text\"/><br/></br>";

    $("#NumberOfAnswersDiv").append(textBox);
   
});

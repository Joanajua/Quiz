function confirmDelete(uniqueId, isDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}


//$( document ).ready(function() {
//    $("#answer-with-checkbox input:checkbox").click(function () {
//        $("#answer-with-checkbox input:checkbox").prop('checked', false);
//        $(this).prop('checked', true);
//    });
//});

//$(document).ready(function () {
//    var array = [];
//    var question1 = document.getElementById("#Q-0");
//    var question2 = document.getElementById("#Q-1");
//    var question3 = document.getElementById("#Q-2");
//    var question4 = document.getElementById("#Q-3");

//    array.push(question1, question2, question3, question4);

//    for (var i = 0; i < array.length; i++)
//    {
//        $("array[i] input:checkbox").click(function () {
//            $("array[i] input:checkbox").prop('checked', false);
//            $(this).prop('checked', true);
//        });
//    }
//});

$(document).ready(function () {
    $("#Q-0 input:checkbox").click(function () {
        $("#Q-0 input:checkbox").prop('checked', false);
        $(this).prop('checked', true);
    });

    $("#Q-1 input:checkbox").click(function () {
        $("#Q-1 input:checkbox").prop('checked', false);
        $(this).prop('checked', true);
    });

    $("#Q-2 input:checkbox").click(function () {
        $("#Q-2 input:checkbox").prop('checked', false);
        $(this).prop('checked', true);
    });

    $("#Q-3 input:checkbox").click(function () {
        $("#Q-3 input:checkbox").prop('checked', false);
        $(this).prop('checked', true);
    });
});

//function IsOneBoxChecked() {
//    if ($("#Q-0 input:checkbox").is('checked', true));
//}
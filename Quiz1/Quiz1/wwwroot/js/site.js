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

// TODO - re-write this function

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

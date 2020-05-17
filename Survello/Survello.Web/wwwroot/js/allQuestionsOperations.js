
$("#btnAddTQ").on('click', function () {
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: '/FormsView/AddTextQuestion',
        success: function (partialView) {
            console.log("partialView: " + partialView);
            $('#textQuestionsContainer').html(partialView);
        }
    });
});


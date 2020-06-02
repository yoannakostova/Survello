$(function () {
    $(document).on('click', '#deleteButton', function () {        
        let title = $(this).data("name");
        let formid = $(this).data("id");
        $("#examplemodal3").html("delete following form: " + title);
        $("#hiddenid").remove("value");
        $("#hiddenid").attr("value", formid);
    });
});
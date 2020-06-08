$(function () {
    $(document).on('click', '#deleteButton', function () {        
        let title = $(this).data("name");
        console.log(title);
        let formid = $(this).data("id");
        console.log(formid);

        //$("#hiddenid").remove("value");
    
        //$("#hiddenid").attr("value", formid);

    });
});
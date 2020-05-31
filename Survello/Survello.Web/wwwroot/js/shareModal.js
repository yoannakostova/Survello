function showModal(id) {
    $(`.${id}`).modal('show');
};

function saveModal(id) {
    let inputField = document.getElementById(id + '+rec');
    let recipients = $(inputField).val();
    let inputField2 = document.getElementById(id + '+subject');
    let subject = $(inputField2).val();

    $(`.${id}`).modal('hide');

    $.ajax({
        type: "Post",
        url: "/FormSender/SendMail",
        data: {
            'id': id,
            'allRecipients': recipients,
            'subj': subject,
        },
        //'RequestVerificationToken': '@AntiForgery.GetAndStoreTokens(HttpContext).RequestToken'
        //headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
    })
};
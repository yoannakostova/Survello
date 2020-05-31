let isEverythingOkGlobal = true;

function ValidateInput(title, id, type) {
    let idPrefix = "";

    if (type === "option") {
        idPrefix = '#idSpanTitleOption_';
    }
    else if (type === "question") {
        idPrefix = '#idSpanTitle_';
    }
    if (!title) {

        $(idPrefix + id.toString()).text("This is a required field");
        isEverythingOkGlobal = false;
        return false;
    }
    else {

        $('#idSpanTitle_' + id.toString()).text("");
        return true;
    }
}
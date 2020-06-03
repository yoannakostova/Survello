function create() {

    isEverythingOkGlobal = true;

    let title = document.getElementById("formTitle").value;

    let idd;
    if (typeOfAction === "Edit") {
        idd = document.getElementById("guid").value;
    }

    let isEverythingOk = true;

    isEverythingOk = ValidateInput(title, 0, "question");

    let description = document.getElementById("formDescription").value;

    let TQlist = new Array();
    let MCQlist = new Array();
    let DQlist = new Array();

    for (let i = 1; i <= globalQuestionID; i++) {

        //CREATE TEXT QUESTION
        let textQuestionIsRequired = false;
        let textQuestionIsLongAnswer = false;

        if (document.getElementById('descriptionTQ_' + i.toString()) !== null) {

            let textQuestionDescription = document.getElementById('descriptionTQ_' + i.toString()).value;
            isEverythingOk = ValidateInput(textQuestionDescription, i, "question");

            let isLongAnswer = document.getElementById('isLongAnswerTQ_' + i.toString());
            let tqIsRequired = document.getElementById('isRequiredTQ_' + i.toString());
            let GCvalue = document.getElementById('getValueTQ_' + i.toString()).value;

            if (isLongAnswer.checked) {
                textQuestionIsLongAnswer = true;
            }
            if (tqIsRequired.checked) {
                textQuestionIsRequired = true;
            }

            let CreateTextQuestionViewModel = {}
            CreateTextQuestionViewModel.Description = textQuestionDescription;
            CreateTextQuestionViewModel.IsLongAnswer = textQuestionIsLongAnswer;
            CreateTextQuestionViewModel.IsRequired = textQuestionIsRequired;
            CreateTextQuestionViewModel.QuestionNumber = GCvalue;

            TQlist.push(CreateTextQuestionViewModel);
        }

        //CREATE MULTIPLE CHOICE QUESTION
        let MCQIsRequired1 = false;
        let MCQisMultipleAnswer1 = false;

        if (document.getElementById('descriptionMCQ_' + i.toString()) !== null) {

            let MCQDescription = document.getElementById('descriptionMCQ_' + i.toString()).value;
            isEverythingOk = ValidateInput(MCQDescription, i, "question");

            let MCQisRequired = document.getElementById('isRequiredMCQ_' + i.toString());
            let MCQisMultipleAnswer = document.getElementById('isMultipleAnswerMCQ_' + i.toString());
            let GCvalue = document.getElementById('getValueMCQ_' + i.toString()).value;

            if (MCQisRequired.checked) {
                MCQIsRequired1 = true;
            }
            if (MCQisMultipleAnswer.checked) {
                MCQisMultipleAnswer1 = true;
            }

            let info = $(`#add_${i} :input`); //1 input -> length = 2

            let optionsCount = 0;

            let OptionDesc = new Array()
            for (let k = 0; k < info.length; k++) {

                let optionMCQ = info[k].localName;

                if (optionMCQ === "input") {

                    optionsCount++

                    let optionMCQvalue = info[k].value
                    let idOption = info[k].id;

                    idOption = idOption.split("_")[1]

                    isEverythingOk = ValidateInput(optionMCQvalue, idOption, "option");

                    if (isEverythingOk) {
                        OptionDesc.push(optionMCQvalue);
                    }
                }
            }

            if (optionsCount < 2) {
                isEverythingOkGlobal = false;
                $(`#corret_${i}`).text("Please add at least 2 options");
            }
            else {
                $(`#corret_${i}`).text("");
            }

            let CreateMultipleChoiceQuestionViewModel = {}

            CreateMultipleChoiceQuestionViewModel.Description = MCQDescription;
            CreateMultipleChoiceQuestionViewModel.IsRequired = MCQIsRequired1;
            CreateMultipleChoiceQuestionViewModel.IsMultipleAnswer = MCQisMultipleAnswer1;
            CreateMultipleChoiceQuestionViewModel.OptionsDescriptions = OptionDesc;
            CreateMultipleChoiceQuestionViewModel.QuestionNumber = GCvalue;

            MCQlist.push(CreateMultipleChoiceQuestionViewModel);
        }

        //CREATE DOCUMENT QUESTION
        let documentQuestionIsRequired = false;

        if (document.getElementById('descriptionDQ_' + i.toString()) !== null) {
            let documentQuestionDescription = document.getElementById('descriptionDQ_' + i.toString()).value;
            isEverythingOk = ValidateInput(documentQuestionDescription, i, "question");

            let dqIsRequired = document.getElementById('isRequiredDQ_' + i.toString());
            let fileSize = $('#FileSize_' + i.toString()).find(":selected").text();
            let fileNumberLimit = $('#FileNumberLimit_' + i.toString()).find(":selected").text();
            let GCvalue = document.getElementById('getValueDQ_' + i.toString()).value;

            if (dqIsRequired.checked) {
                documentQuestionIsRequired = true;
            }

            let CreateDocumentQuestionViewModel = {}
            CreateDocumentQuestionViewModel.Description = documentQuestionDescription;
            CreateDocumentQuestionViewModel.IsRequired = documentQuestionIsRequired;
            CreateDocumentQuestionViewModel.FileSize = fileSize;
            CreateDocumentQuestionViewModel.FileNumberLimit = fileNumberLimit;
            CreateDocumentQuestionViewModel.QuestionNumber = GCvalue;

            DQlist.push(CreateDocumentQuestionViewModel);
        }
    }
    if (typeOfAction === "Create") {

        if (isEverythingOkGlobal && isEverythingOk) {
            $.ajax({
                type: 'Post',
                url: 'Create',
                data: {
                    'Title': title,
                    'Description': description,
                    'TextQuestions': TQlist,
                    'MultipleChoiceQuestions': MCQlist,
                    'DocumentQuestions': DQlist
                },
                success: function () {
                    window.location.replace("/Form/ListForms")
                }
            })
        }
        else {
            alert("There are required fields remaining unfilled.")
            window.scrollTo(0, 0);
        }
    }
    else {
        if (isEverythingOkGlobal && isEverythingOk) {
            $.ajax({
                type: 'Post',
                url: 'Edit',
                data: {
                    'Id': idd,
                    'Title': title,
                    'Description': description,
                    'TextQuestions': TQlist,
                    'MultipleChoiceQuestions': MCQlist,
                    'DocumentQuestions': DQlist
                },
                success: function () {
                    window.location.replace("/Form/ListForms")
                }
            })
        }
        else {
            alert("There are required fields remaining unfilled.")
            window.scrollTo(0, 0);
        }
    }
}
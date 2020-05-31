$('#btnAddTQ').on('click', () => {
    counter++;
    globalQuestionID++;
    let globalRemoveID_Const = event.target.getAttribute('data-arg1');
    let globalRemoveID = parseInt(globalRemoveID_Const) + counter;

    let div = document.getElementById('questions')
    let element =
        `<div style="color:darkcyan" class="card" id="RemoveID_${globalRemoveID}">
                        <div class="card-header" style="background-color:darkcyan">
                            <div class="row">
                                <div class="col-md-10">
                                    <input type="text" class="form-control" id="descriptionTQ_${globalQuestionID}" placeholder="Enter your question">
                                    <span id="idSpanTitle_${globalQuestionID}" style="color:red"></span>
                                </div>
                                <div class="fa fa-times" id="globalCounter">
                                    <button type="button" class="btn btn-danger btn-circle" onclick="RemoveID(this.id)" id="${globalRemoveID}">X</button>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="custom-control custom-switch">
                            <input type="checkbox" class="custom-control-input" id="isLongAnswerTQ_${globalQuestionID}">
                            <label class="custom-control-label" for="isLongAnswerTQ_${globalQuestionID}">Long answer</label>
                        </div>
                        <div class="custom-control custom-switch">
                            <input type="checkbox" class="custom-control-input" id="isRequiredTQ_${globalQuestionID}" />
                            <label class="custom-control-label" for="isRequiredTQ_${globalQuestionID}">Required</label>
                        </div>
                        <br />
                    </div>
                    <input style="display:none" id=getValueTQ_${globalQuestionID} value="${globalQuestionID}" />
                    <br />
                    <br />`
    $(div).append(element)
})

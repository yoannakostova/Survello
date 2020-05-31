$('#btnAddMCQ').on('click', () => {
    counter++;
    globalQuestionID++;

    let globalRemoveID_Const = event.target.getAttribute('data-arg1');
    let globalOptionsID = event.target.getAttribute('data-arg2');
    let globalRemoveID = parseInt(globalRemoveID_Const) + counter;
    let div = document.getElementById('questions')

    let element =
        `<div style="color:darkcyan" class="card" id="RemoveID_${globalRemoveID}">
                       <div class="card-header" style="background-color:darkcyan">
                           <div class="row">
                               <div class="col-md-10">
                                   <input type="text" class="form-control" id="descriptionMCQ_${globalQuestionID}" placeholder="Enter your question" />
                                   <span id="idSpanTitle_${globalQuestionID}" style="color:red"></span>
                               </div>
                               <div class="fa fa-times" id="globalCounter">
                                   <button onclick="RemoveID(this.id)" class="btn btn-danger btn-circle" id="${globalRemoveID}">X</button>
                               </div>
                           </div>
                       </div>
                       <br />
                      <div class="custom-control custom-switch">
                              <input asp-for="IsRequired" type="checkbox" class="custom-control-input" id="isRequiredMCQ_${globalQuestionID}">
                              <label class="custom-control-label" for="isRequiredMCQ_${globalQuestionID}">Required</label>
                              <span asp-validation-for="IsRequired" class="text-danger"></span>
                        </div>
                       <div class="custom-control custom-switch">
                           <input asp-for="IsMultipleAnswer" type="checkbox" class="custom-control-input" id="isMultipleAnswerMCQ_${globalQuestionID}">
                           <label class="custom-control-label" for="isMultipleAnswerMCQ_${globalQuestionID}">Multiple Answer</label>
                           <span asp-validation-for="IsMultipleAnswer" class="text-danger"></span>
                       </div>
                       <br />
                       <div id="add_${globalQuestionID}">
                           <span style="color:red" id="corret_${globalQuestionID}"></span>
                       </div>
                       <br />
                       <div class="container">
                           <div id="counter">
                               <button onclick="addOption(this.id)" class="btn btn-outline-secondary" id=${globalQuestionID} data-arg1="${globalRemoveID_Const}" data-arg2="${globalOptionsID}">Add Option</button>
                           </div>
                       <br />
                       <input style="display:none" id=getValueMCQ_${globalQuestionID} value="${globalQuestionID}" />
                       </div>
                   </div>
                   <br />
                   <br />`
    $(div).append(element)
})

function addOption(id) {
    counter++;
    opt++;

    let globalRemoveID = event.target.getAttribute('data-arg1');
    let globalOptionsID = event.target.getAttribute('data-arg2');

    globalRemoveID = parseInt(globalRemoveID) + counter;
    globalOptionsID = parseInt(globalOptionsID) + opt;

    let div = document.getElementById("add_" + id)
    let element =
                            `<div class="row" id="RemoveID_${globalRemoveID}">
                               <div class="col-md-8">
                                   <input type="text" class="form-control" id="option_${globalOptionsID}" placeholder="Enter your text here">
                                   <span id="idSpanTitleOption_${globalOptionsID}" style="color:red"></span>
                               </div>
                               <div class="fa fa-times" id="globalCounter">
                                   <button type="button" class="btn btn-danger btn-circle" onclick="RemoveID(this.id)" id="${globalRemoveID}">X</button>
                               </div>
                             </div>
                             <br />`
    $(div).append(element)
}
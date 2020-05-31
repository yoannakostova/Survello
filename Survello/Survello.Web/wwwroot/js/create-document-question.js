let dq = 0;
$('#btnAddDQ').on('click', () => {

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
                                      <input type="text" class="form-control" id="descriptionDQ_${globalQuestionID}" placeholder="Enter your question">
                                      <span id="idSpanTitle_${globalQuestionID}" style="color:red"></span>
                                  </div>
                                  <div class="fa fa-times" id="globalCounter">
                                      <button type="button" class="btn btn-danger btn-circle" onclick="RemoveID(this.id)" id="${globalRemoveID}">X</button>
                                  </div>
                              </div>
                          </div>
                          <div class="container">
                              <div class="row">
                                  <div class="dropdown pull-left; col-md-4" id="FileNumberLimit_${globalQuestionID}">
                                      <label class="control-label">
                                          Files limit
                                          <select id="select1" class="form-control">
                                              <option value="1">1</option>
                                              <option value="2">2</option>
                                              <option value="3">3</option>
                                              <option value="4">4</option>
                                              <option value="5">5</option>
                                              <option value="6">6</option>
                                              <option value="7">7</option>
                                              <option value="8">8</option>
                                              <option value="9">9</option>
                                              <option value="10">10</option>
                                          </select>
                                      </label>
                                  </div>
                                  <div class="dropdown pull-right; col-md-4" id="FileSize_${globalQuestionID}">
                                      <label class="control-label">
                                          File size
                                          <select id="select1" class="form-control">
                                              <option value="1">1MB</option>
                                              <option value="10">10MB</option>
                                              <option value="100">100MB</option>
                                              <option value="1000">1GB</option>
                                          </select>
                                      </label>
                                  </div>
                              </div>
                          </div>
                          <br />
                          <div class="custom-control custom-switch">
                              <input type="checkbox" class="custom-control-input" id="isRequiredDQ_${globalQuestionID}">
                              <label class="custom-control-label" for="isRequiredDQ_${globalQuestionID}">Required</label>
                          </div>
                          <br />
                          <input style="display:none" id=getValueDQ_${globalQuestionID} value="${globalRemoveID}" />
                      </div>
                      <br />
                      <br />`
    $(div).append(element)
});
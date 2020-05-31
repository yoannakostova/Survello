function RemoveID(id) {
    let toBeRemoved = "RemoveID_" + id;
    let element = document.getElementById(toBeRemoved)
    element.remove();
}
function enterCat(id) {

    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById('grid').innerHTML = this.responseText;
            doAllBtn()
        }
    };
    xhr.open('get', '/cat/index?handler=enterCatPartial&catid=' + id);
    xhr.send();
}

function exitCat(id) {

    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById('grid').innerHTML = this.responseText
        }
    };
    xhr.open('get', '/cat/index?handler=exitCatPartial&catid=' + id);
    xhr.send();

}

function chooseCatProperty(propid, propname) {

    const el_name = document.querySelector("input[data-stuff-requests='name']");
    const el_id = document.querySelector("input[data-stuff-requests='id']");

    //const el_name = document.querySelector("input.guide-value");
    //const el_id = document.querySelector("input.guide-id");

    el_name.value = propname;
    el_id.value = propid;

    bootstrap.Modal.getInstance(document.getElementById('staticBackdrop')).hide()
}

//document.forms.newcatform.onsubmit = () => {

//    let formData = new FormData(document.forms.newcatform);
//    formData.append('catid', document.getElementById('catid-current').value);

//    var xhr = new XMLHttpRequest();
//    xhr.onreadystatechange = function () {
//        if (this.readyState === 4 && this.status === 200) {
//            document.getElementById('grid').innerHTML = this.responseText;
//            document.forms.newcatform.reset();
//        }
//    };

//    xhr.open('post', '/cat/index?handler=AddCat', true);
//    xhr.send(new URLSearchParams(formData));
//    return false;
//};

//document.forms.catproperty.onsubmit = () => {

//    let formData = new FormData(document.forms.catproperty);
//    formData.append('catid', document.getElementById('catid-current').value);

//    var xhr = new XMLHttpRequest();
//    xhr.onreadystatechange = function () {
//        if (this.readyState === 4 && this.status === 200) {
//            document.getElementById('grid').innerHTML = this.responseText;
//            document.forms.catproperty.reset();
//        }
//    };

//    xhr.open('post', '/cat/index?handler=AddProperty', true);
//    xhr.send(new URLSearchParams(formData));
//    return false;
//};

window.addEventListener("load", () => doAllBtn());

function doAllBtn() {
    var elems = document.querySelectorAll('.guide-stuff');

    elems.forEach(item => {
        
        item.addEventListener('click', function () {
            chooseCatProperty(item.dataset.guideStuffId, item.dataset.guideStuffName)
        }, false);
    })

    var elems_cat = document.querySelectorAll('.guide-category');

    elems_cat.forEach(item => {
        
        item.addEventListener('click', function () {
            enterCat(item.dataset.guideCategoryId)
        }, false);
    })
}
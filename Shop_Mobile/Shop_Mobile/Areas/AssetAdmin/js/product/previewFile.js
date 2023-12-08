function previewFile(inputId, imgId) {
    console.log("Calling previewFile for", imgId);
    var preview = document.getElementById(imgId);
    var fileInput = document.getElementById(inputId);
    var file = fileInput.files[0];
    var reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
    }

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
    }
}

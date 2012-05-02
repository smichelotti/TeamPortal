///Reference: http://www.html5rocks.com/en/tutorials/file/dndfiles/
/*globals FileReader,document */

function handleFileSelect(evt) {
    var files = evt.target.files; // FileList object

    // Loop through the FileList and render image files as thumbnails.
    for (var i = 0, f; f = files[i]; i++) {
        // Only process image files.
        if (!f.type.match('image.*')) {
            continue;
        }

        var reader = new FileReader();

        // Closure to capture the file information.
        reader.onload = (function (theFile) {
            return function (e) {
                var div = document.getElementById("playerImg");
                div.innerHTML = '<img src="' + e.target.result + '" />';
            };
        })(f);

        // Read in the image file as a data URL.
        reader.readAsDataURL(f);
    }
}

document.getElementById('PhotoToUpload').addEventListener('change', handleFileSelect, false);
function fileHandler(blobInfo, success, failure) {
    var formData = new FormData();
    formData.append('file', blobInfo.blob(), blobInfo.filename());

    fetch('/FileHandler.razor', {
        method: 'POST',
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            success(data.imageUrl);
        })
        .catch(error => {
            failure('Image upload failed');
        });
}
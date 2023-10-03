<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Import Page</title>
    <!-- Add any necessary CSS or JavaScript libraries -->
</head>
<body>
    <form id="form1" runat="server">
        <!-- ImportPage.aspx -->
        <input type="file" id="fileInput" />
        <button type="button" id="btnUpload">Upload</button>
        <button type="button" id="btnCancel" style="display:none;">Cancel</button>
        <div id="dialog" style="display:none;">
            <span id="dialogText">File uploaded successfully!</span>
            <button type="button" id="btnOK" style="display:none;">OK</button>
        </div>

        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script type="text/javascript">
            var xhr; // Global variable to hold the XMLHttpRequest object

            $(document).ready(function () {
                // Function to handle file upload asynchronously
                function uploadFile() {
                    var fileInput = document.getElementById('fileInput');
                    var formData = new FormData();
                    formData.append('file', fileInput.files[0]);

                    // Display a loading message
                    $("#dialogText").text("Uploading file...");

                    xhr = $.ajax({
                        url: 'UploadHandler.ashx', // Use a separate handler for file upload
                        type: 'POST',
                        data: formData,
                        processData: false,
                        contentType: false,
                        xhr: function () {
                            // Create an XMLHttpRequest with progress event support
                            var xhr = new window.XMLHttpRequest();
                            xhr.upload.addEventListener("progress", function (evt) {
                                if (evt.lengthComputable) {
                                    var percentComplete = (evt.loaded / evt.total) * 100;
                                    $("#dialogText").text("Uploading: " + percentComplete.toFixed(2) + "%");
                                }
                            }, false);
                            return xhr;
                        },
                        success: function (data) {
                            showSuccessDialog(data);
                        },
                        // Handle the error callback
                        error: function (xhr, status, error) {
                            var errorMessage;
                            if (xhr.responseText) {
                                errorMessage = xhr.responseText; // Use the response text if available
                            } else {
                                errorMessage = "An error occurred during the upload.";
                            }
                            showErrorDialog(errorMessage);
                        }

                    });
                    $("#btnCancel").show(); // Show the cancel button
                }

                // Function to cancel the upload
                function cancelUpload() {
                    if (xhr && xhr.readyState !== 4) {
                        xhr.abort();
                        showErrorDialog("Upload canceled.");
                    }
                }

                // Function to show the success dialog
                function showSuccessDialog(message) {
                    $("#dialogText").text(message);
                    $("#btnOK").show();
                    $("#btnCancel").hide();
                    $("#dialog").show();
                }

                // Function to show an error dialog
                function showErrorDialog(errorMsg) {
                    $("#dialogText").text("Error: " + errorMsg);
                    $("#btnOK").show();
                    $("#btnCancel").hide();
                    $("#dialog").show();
                }

                // Function to hide the dialog
                function hideDialog() {
                    $("#dialog").hide();
                }

                // Attach click event handlers
                $("#btnUpload").click(uploadFile);
                $("#btnCancel").click(cancelUpload);
                $("#btnOK").click(hideDialog);
            });
        </script>
    </form>
</body>
</html>

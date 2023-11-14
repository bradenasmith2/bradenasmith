document.addEventListener("DOMContentLoaded", function () {
    // Get references to the button and the comment box
    const showCommentButton = document.getElementById("showCommentButton");
    const commentBox = document.getElementById("commentBox");

    // Add an event listener to the "Show Comment Box" button
    showCommentButton.addEventListener("click", function () {
        // Toggle the display of the comment box when the button is clicked
        if (commentBox.style.display === "none") {
            commentBox.style.display = "block";
            showCommentButton.innerHTML = "Hide Comment Box";
        } else {
            commentBox.style.display = "none";
            showCommentButton.innerHTML = "Add a Comment";
        }
    });

    // Get a reference to the "Add Comment" button and the comment textarea
    const addCommentButton = document.getElementById("addCommentButton");
    const commentText = document.getElementById("commentText");

    // Add an event listener to the "Add Comment" button
    addCommentButton.addEventListener("click", function () {
        // Get the comment text from the textarea
    });
});

$(document).ready(function () {
    $(".edit-button").on("click", function () {
        var commentContent = $(this).data("comment-content");
        var editForm = $(this).siblings(".edit-form");
        editForm.find("textarea").val(commentContent);
        editForm.toggle();
        $(this).siblings(".comment-content").toggle();
    });
});


function toggleEditAndDeleteButtons(button) {
    var editForm = button.nextElementSibling; // Assuming the edit form is always the next sibling
    var deleteForm = editForm.nextElementSibling; // Assuming the delete form is the next sibling of the edit form

    if (editForm.style.display === 'none') {
        // "Edit" button is pressed, show both "Confirm Changes" and "Delete" buttons
        editForm.style.display = 'block';
        deleteForm.style.display = 'block';

    } else {
        // "Edit" button is not pressed, hide both "Confirm Changes" and "Delete" buttons
        editForm.style.display = 'none';
        deleteForm.style.display = 'none';
    }
}

function toggleDeleteButton() {
    var deleteForm = document.getElementById('deleteForm');

    if (deleteForm.style.display === 'none') {
        deleteForm.style.display = 'block';
    } else {
        deleteForm.style.display = 'none';
    }
}
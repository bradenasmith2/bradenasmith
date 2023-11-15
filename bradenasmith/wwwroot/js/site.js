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
        var commentContent = $(this).siblings(".comment-content");
        var editForm = $(this).siblings(".edit-form");
        var textarea = editForm.find("textarea");

        if (editForm.is(":hidden")) {
            // "Edit" button is pressed, show the edit form and hide the comment content
            textarea.val(commentContent.text().trim());
            editForm.show();
            commentContent.hide();
        } else {
            // "Edit" button is pressed again, hide the edit form and show the comment content
            editForm.hide();
            commentContent.show();
        }
    });

    $(".delete-button").on("click", function () {
        var deleteForm = $("#deleteForm");
        deleteForm.toggle();
    });
});


function toggleEditAndDeleteButtons(button) {
    var editForm = button.nextElementSibling; // Assuming the edit form is always the next sibling
    var deleteForm = editForm.nextElementSibling; // Assuming the delete form is the next sibling of the edit form

    if (editForm.style.display === 'none') {
        // "Edit" button is pressed, show both "Confirm Changes" and "Delete" buttons
        editForm.style.display = 'inline-block';
        deleteForm.style.display = 'inline-block';

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
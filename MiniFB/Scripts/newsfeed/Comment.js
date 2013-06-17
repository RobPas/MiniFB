var ShowCommentForm = function (id) {
    $("#comment-form-" + id).toggle();
}

var showAllComments = function (id) {

    $("#comment-hidden-" + id).slideToggle('fast', function () {
        // Animation complete.
    });
}

var SendComment = function (writer, newsfeeditemguid) {

    if ($("#commenttext-" + newsfeeditemguid).val() != "") {

        var message = $("#commenttext-" + newsfeeditemguid).val();

        $.ajax("/NewsFeedItem/AddComment/", {

            type: 'POST',

            data: { newsfeedid: newsfeeditemguid, commenttext: message },

            success: function () {
                $("#comments-" + newsfeeditemguid + " ul").first().next().append("<li><strong>" + writer + ":</strong> " + message + "</li>").fadeOut("fast").fadeIn("fast");
                $("#commenttext-" + newsfeeditemguid).val("");
            },
            error: function () {

            },
            beforeSend: function () {

            },
            complete: function () {

            }
        });
    }
}

$(document).ready(function () {


    $(".submit-comment").click(function (e) {
        e.preventDefault();
        
    });

    $(".showCommentsButton").click(function (e) {
        e.preventDefault();
        $(this).text(function (i, text) {
            return text === "Visa fler kommentarer" ? "Dölj kommentarer" : "Visa fler kommentarer";
        })
    });

    


});
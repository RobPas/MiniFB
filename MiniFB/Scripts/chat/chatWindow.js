$(document).ready(function () {

    $(".chat-footer").click(function () {
        $("#message").focus().click();
        $(".chat-window").slideToggle("fast");
    });

    $(".chat-header").click(function () {
        $("#message").focus().click();
        $(".chat-window").slideToggle("fast");
    });

    $("#remove-history").click(function () {
        $("#discussion").html("");
    });

    $('#message').keypress(function (e) {
        if (e.which == 13) {
            $(this).blur();
            $('#sendmessage').focus().click();
        }
    });



    // Declare a proxy to reference the hub.
    var chat = $.connection.chatHub;

    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message, image, datestamp) {
        // Html encode display name and message.
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page.
        $('#discussion').append('<li style="margin-top:2px;" ><img style="height:40px;" src="' + image + '"/> <strong style="display:block;margin-top: -40px; margin-left: 45px;">' + encodedName
            + '</strong><em style="display:block; margin-left:45px;">' + encodedMsg + '</em><em style="display:block; margin-left:45px;font-size:10px;">Skickat: ' + datestamp + '</em></li>');
        $(".chat-window").slideDown("fast");
        $("#chatMessages").animate({ scrollTop: $("#chatMessages")[0].scrollHeight }, 300);
    };
    // Get the user name and store it to prepend to messages.
    $('#displayname').val();
    // Set initial focus to message input box.
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            if ($('#message').val() != "") { chat.server.distribute($('#displayname').val(), $('#message').val()); }
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });


});
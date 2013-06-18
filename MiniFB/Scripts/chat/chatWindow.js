$(document).ready(function () {

    $(".chat-footer").click(function () {
        $("#message").focus().click();
        $(".chat-window").slideToggle("fast");
    });

    $(".chat-header").click(function () {
        $("#message").focus().click();
        $(".chat-window").slideToggle("fast");
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
    chat.client.broadcastMessage = function (name, message) {
        // Html encode display name and message.
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page.
        $('#discussion').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
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
            chat.server.distribute($('#displayname').val(), $('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });


});
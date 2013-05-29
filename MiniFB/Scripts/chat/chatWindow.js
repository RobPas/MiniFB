$(document).ready(function () {
    $(".chat-footer").click(function () {
        $(".chat-window").slideToggle("slow");
        $(".chat-content").click(function (event) {
            event.stopPropagation();
        });
    });
    $(".chat-header").click(function () {
        $(".chat-window").slideToggle("slow");
    });
});
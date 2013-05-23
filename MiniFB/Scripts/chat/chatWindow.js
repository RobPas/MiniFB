$(document).ready(function () {
    $(".chat").click(function () {
        $(".chat-window").slideToggle("slow");
        $(".chat-content").click(function (event) {
            event.stopPropagation();
        });
    });
});
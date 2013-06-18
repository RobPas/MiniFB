$(document).ready(function () {
    $("#video-preview").addClass("hide");

    $("#Data").keyup(function () {
        var url = $("#Data").val();

        /* Kollar efter ett video id från en youtube url och plockar ut det. */
        if (url.indexOf("youtube.com") !== -1) {
            var splited_url1 = url.toString().split('v=');
            if (splited_url1[1] != undefined) {
                var splited_url2 = splited_url1[1].split('#');
                var video_id = splited_url2[0].split('&');
                var newURL = "http://www.youtube.com/embed/" + video_id[0];


                $("#preview-iframe").attr("src", newURL);
                $("#video-preview").removeClass("hide");
                $("#Data").attr("data-video-url", newURL);
            } else {
                $("#video-preview").addClass("hide");
            }
        } else {
            $("#video-preview").addClass("hide");
            $("#img-pre").attr("src", url);
        }

    });
});
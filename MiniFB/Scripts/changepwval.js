$(document).ready(function () {

    $("input").blur(function () {
        validate();
    });

    $(document).keyup(function () {
        validate();
    });

    $("#change-pw-form").submit(function (e) {
        if (validate() === false) {
            e.preventDefault();
        }
    });


    function validate() {

        if ($("#oldpassword").val() == "") {
            $("#oldMessage").show();
            $("#oldpassword").css("background", "#FF6666");
            return false;
        } else {
            $("#oldpassword").css("background", "#93DB70");
            $("#oldMessage").hide();
        }

        if ($("#newpassword").val() == "") {
            $("#newMessage").show();
            $("#newpassword").css("background", "#FF6666");
            return false;
        } else {
            $("#newpassword").css("background", "#93DB70");
            $("#newMessage").hide();
        }

        if ($("#confirmpassword").val() == $("#newpassword").val()) {
            $("#confirmpassword").css("background", "#93DB70");
            $("#confirmMessage").hide();
        } else {
            $("#confirmMessage").show();
            $("#confirmpassword").css("background", "#FF6666");
            return false;
        }
        return true;
    }

});
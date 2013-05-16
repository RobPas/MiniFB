// En javascript-fil för att samla praktiska verktyg till chat-appen

var ChatUtils = {
    //Funktion för att omvandla ett javascript Date-objekt till string
    DateToString: function (d) {

        return d.getFullYear() + '-' + (d.getMonth() + 1) + '-' + d.getDate() + ' ' + d.getHours() + ':' + d.getMinutes() + ':' + d.getSeconds();
    },

    //Funktion för att omvandla ett JSON-datum till javascript Date-objekt
    DateFromBackend: function (d) {
        return new Date(parseInt(d.substr(6)));

    },
    
    //Funktion för att visa felmeddelandet på sidan
    ShowError: function (msg) {
        $("#errorDisplay").text(msg).fadeIn('slow').delay(1000).fadeOut('slow');
    }

}

$(document).ready(function () {
    
    //Koppla på en animeringsfunktion för att dölja och visa chatfönstret
    $('#chatCloser').click(function () {
        $('#chatBox').slideToggle('slow', 'easeOutBounce');
    });
    
    if ($("#chatMessages").html() == "") {
        $("#chatMessages").html("<p id='noTextFiller'>Här fanns inget ännu..</p>");
    }

});
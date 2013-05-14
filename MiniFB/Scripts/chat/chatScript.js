/// <reference path="ChatUtils.js" />
/// <reference path="../jquery-1.5.1.js" />


$(document).ready(function () {

    //Håll reda på tidsstämpeln på det senaste meddelandet (så att vi hela tiden hämtar meddelanden som är nya sen sist)
    var lastCheckForMessages = new Date();

    //Funktion för att hämta chatmeddelandena via AJAX och visa dem i chat-fönstret
    var GetChatMessages = function () {

        $.ajax('/Chat/GetChatMessages/', {
            success: function (data) {

                //Ifall vi fått några nya meddelanden så vill vi animera chatfönstret för att påkalla användarens uppmärksamhet
                if (data.length > 0) {
                    $("#chatCloser").animate({ backgroundColor: 'Yellow' }, 300)
                    .animate({ backgroundColor: 'Blue' }, 300)
                    $("#noTextFiller").remove();
                }


                //Chatmeddelandena skickas i en JSON-array, gå igenom hela arrayen objekt för objekt och lägg till innehållet i chatrutan.
                //Index är vilket index i arrayen objektet har och value är själva objektet
                $.each(data, function (index, value) {

                    //Plocka ut tidsstämpeln för chatmeddelandet och konvertera från JSON-datum till ett Javascript Date-objekt
                    var rawJsDate = ChatUtils.DateFromBackend(value.timestamp);
                    //Skapa html-element för att visa datumet
                    var datumet = $('<em>').text(ChatUtils.DateToString(rawJsDate));
                    //Skapa html-element för att visa användarnamnet
                    var username = $('<strong>').text(value.username);
                    
                    //Skapa html-element för att visa meddelandet
                    var chatMsg = $('<p>').text(value.message);

                    //Lägg till de nya html-elementen till något på sidan (chatMessages-rutan) för att användaren skall kunna se dem
                    $('#chatMessages').append(datumet).append(" - ").append(username).append(chatMsg);

                    //Spara ner tidsstämpeln på meddelandet som det nya "lastCheck" för att vi i nästa anrop skall få alla meddelanden som kommit efter detta
                    if (rawJsDate > lastCheckForMessages) {
                        lastCheckForMessages = rawJsDate;
                    }

                });

                //Gör så att chatrutan scrollar med innehållet automatiskt
                $("#chatMessages").animate({ scrollTop: $("#chatMessages")[0].scrollHeight }, 300);

            },
            error: function () {
                ChatUtils.ShowError("Kunde inte hämta meddelanden via AJAX");
            },
            
            //Visa loadern
            beforeSend: function () {
                $("#chatLoader").fadeIn('slow');
            },
            //Göm loadern
            complete: function () {
                $("#chatLoader").fadeOut('slow');
            },

            //Datan som behöver skickas med är datumet till lastCheck (i JSON-format, dvs string)
            data: { lastCheck: ChatUtils.DateToString(lastCheckForMessages) }

        });

    };


    //Funktion för att skicka nya chatmeddelanden från browsern till servern
    var SendChatMessage = function (message) {

        $.ajax("/Chat/StoreChatMessage/", {

            type: 'post',
            
            //Skicka med meddelande i JSON-format
            data: { newMessage: message },


            success: function (data) {

                //Uppdatera chatrutan
                GetChatMessages();
                $("#chatInput").val("").focus();

            },
            error: function () {
                ChatUtils.ShowError("Kunde inte skicka meddelanden till servern");
            },
            beforeSend: function () {
                $("#chatLoader").fadeIn('slow');
            },
            complete: function () {
                $("#chatLoader").fadeOut('slow');
            }
        });

    }

    var SendChatMessageToRandom = function (message, toUserID) {

        $.ajax("/Chat/StoreChatMessageToRandom/", {

            type: 'post',

            //Skicka med meddelande i JSON-format
            data: { newMessage: message, sendToID: toUserID },


            success: function (data) {

                //Uppdatera chatrutan
                GetChatMessages();
                $("#chatInput").val("").focus();

            },
            error: function () {
                ChatUtils.ShowError("Kunde inte skicka meddelanden till servern");
            },
            beforeSend: function () {
                $("#chatLoader").fadeIn('slow');
            },
            complete: function () {
                $("#chatLoader").fadeOut('slow');
            }
        });

    }

   

    //Koppla ihop knappens click-event med en funktion som anropar SendChatMessage-funktionen
    $("#chatButton").click(function () {

        var message = $("#chatInput").val();

        if ($("#chatInput").val() !== "") {
            SendChatMessage(message);
        }
    });

    //Random chatt 
    $("#chatButtonRandom").click(function () {

        var message = $("#chatInput").val();
        var toUserID = $("#sendToID").val();

        if ($("#chatInput").val() !== "") {
            SendChatMessageToRandom(message, toUserID);
        }
    });


    //Kolla efter nya chatmeddelanden automatiskt var 5:e sekund
    setInterval(GetChatMessages, 5000);

});
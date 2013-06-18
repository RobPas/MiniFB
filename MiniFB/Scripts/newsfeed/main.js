(function (window, $) {

    var status_el = $('.newsfeed-sorting-current span'),
        container = $('.newsfeed-container:first');

    var ajaxOptions = function (text) {

        return {
            type: 'get',
            success: function (d) {
                if (text !== "")
                    $(status_el).text(text);

                $(container).html(d);
            }
        };
    };

    //var ajaxOptions = {
    //    type: 'get',
    //    success: function (d) {
    //        $(status_el).text(text);

    //        $(container).html(d);
    //    }
    //};

    $('.newsfeed-sorting .dropdown-menu a').on('click', function (e) {
        e.preventDefault();
        
        var url = $(this).prop('href'),
        text = $(this).text();

        if (Modernizr.history) {
            history.pushState({ url: url,  }, null, url);
        }

        $.ajax(url, ajaxOptions(text));
    });

    if (!Modernizr.history)
        return;

    onpopstate = function (event) {
        console.log(event)

        if (event.state !== null) {
            $.ajax(event.state.url, ajaxOptions(""));
        }
    };

}(this, this.jQuery));
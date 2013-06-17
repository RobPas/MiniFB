(function (window, $) {

    $('.newsfeed-sorting .dropdown-menu a').on('click', function (e) {
        e.preventDefault();

        var status_el = $('.newsfeed-sorting-current span'),
            url = $(this).prop('href'),
            text = $(this).text(),
            container = $('.newsfeed-container:first');

        var ajaxOptions = {
            type: 'get',
            success: function (d) {
                $(status_el).text(text);

                $(container).html(d);
            }
        };

        if (Modernizr.history) {
            history.pushState(null, null, url);
        }

        $.ajax(url, ajaxOptions);
    });

}(this, this.jQuery));
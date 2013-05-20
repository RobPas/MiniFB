(function (window, $) {

    $('.newsfeed-sorting .btn').on('click', function (e) {
        e.preventDefault();

        var url = $('h1 a').prop('href'),
            container = $('.newsfeed-items')[0];

        var ajaxOptions = {
            type: 'get',
            data: { filter: $(this).val() },
            success: function (d) {
                $(container).html(d);
            }
        };

        if (Modernizr.history) {
            var url = $('.newsfeed-sorting').prop('action') + "/?filter=" + $(this).val();

            history.pushState(null, null, url);
        }

        $.ajax(url, ajaxOptions);
    });

}(this, this.jQuery));
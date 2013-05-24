(function (window, $) {

    $('.newsfeed-sorting .btn').on('click', function (e) {
        e.preventDefault();

        var url = $('.brand').prop('href'),
            container = $('.newsfeed-container:first');

        var ajaxOptions = {
            type: 'get',
            success: function (d) {
                $(container).html(d);
            }
        };

        if (Modernizr.history) {
            var url = $('.newsfeed-sorting').prop('action') + '/?filter=' + $(this).val();

            history.pushState(null, null, url);
        }

        $.ajax(url, ajaxOptions);
    });

}(this, this.jQuery));
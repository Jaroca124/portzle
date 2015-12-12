$(document).ready(function() {
        $('#overlay1').fadeIn(2000);
        $('#banner_text').delay(1000).fadeIn(2000);
        $('#githublink_button').delay(1000).fadeIn(2000);
});

function load() {
    //Arrow Action
    $('.goto-next').click(function(event) {
        var status = $(this).attr('id').split('_')[1];
        $('html, body').animate({
            scrollTop: $('#' + status).offset().top
        }, 500);
    });

    $('.goto-next-black').click(function(event) {
        var status = $(this).attr('id').split('_')[1];
        $('html, body').animate({
            scrollTop: $('#' + status).offset().top
        }, 500);
    });
}
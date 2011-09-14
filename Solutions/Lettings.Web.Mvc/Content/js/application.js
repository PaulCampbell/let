$(document).ready(function () {
    $('.add-on :checkbox').click(function () {
        if ($(this).attr('checked')) {
            $(this).parents('.add-on').addClass('active');
        } else {
            $(this).parents('.add-on').removeClass('active');
        }
    });
});
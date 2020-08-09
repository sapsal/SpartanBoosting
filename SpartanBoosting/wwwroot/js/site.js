var chkBox = $('.single-select-checkbox');
var chkBoxBorderSingleStyling = $('.checkbox-border-single-styling');
var chkBoxBorderStyling = $('.checkbox-border-styling');
$(".booster-carousel").slick({
    slidesToShow: 4,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 2000,
    dots: false,
    prevArrow: false,
    nextArrow: false
});

$(".slick-carousel").slick({
    slidesToShow: 3,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 2000,
    dots: false,
    prevArrow: false,
    nextArrow: false
});

$('.toast').toast({
    delay: 2000
})

document.addEventListener("DOMContentLoaded", function () {
    var lazyloadImages = document.querySelectorAll("img.lazy");
    var lazyloadThrottleTimeout;

    function lazyload() {
        if (lazyloadThrottleTimeout) {
            clearTimeout(lazyloadThrottleTimeout);
        }

        lazyloadThrottleTimeout = setTimeout(function () {
            var scrollTop = window.pageYOffset;
            lazyloadImages.forEach(function (img) {
                if (img.offsetTop < (window.innerHeight + scrollTop)) {
                    img.src = img.dataset.src;
                    img.classList.remove('lazy');
                }
            });
            if (lazyloadImages.length == 0) {
                document.removeEventListener("scroll", lazyload);
                window.removeEventListener("resize", lazyload);
                window.removeEventListener("orientationChange", lazyload);
            }
        }, 20);
    }

    document.addEventListener("scroll", lazyload);
    window.addEventListener("resize", lazyload);
    window.addEventListener("orientationChange", lazyload);
});


//uncheck checkboxes when it is single only
$(chkBox).on('click', function () {
    if ($(this).prop("checked")) {
        chkBox.prop("checked", false);
        $(this).prop("checked", true);
    }
});

$(chkBoxBorderSingleStyling).on('click', function () {
    if ($(this).prop("checked")) {
        chkBoxBorderSingleStyling.parent().parent().removeClass('wpforms-selected');
        $(this).parent().parent().addClass('wpforms-selected').fadeIn('slow');
    }
});

$(document).on("click", '.checkbox-border-styling', function () {
    debugger;
    if ($(this).prop("checked")) {
        $(this).parent().parent().addClass('wpforms-selected').fadeIn('slow');
    }
    else {
        $(this).parent().parent().removeClass('wpforms-selected');
    }
});

$(function () {
    var requiredCheckboxes = $('.one-checkbox-minimum :checkbox[required]');
    requiredCheckboxes.change(function () {
        if (requiredCheckboxes.is(':checked')) {
            requiredCheckboxes.removeAttr('required');
        } else {
            requiredCheckboxes.attr('required', 'required');
        }
    });
});
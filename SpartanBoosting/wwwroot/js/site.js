var chkBox = $('.single-select-checkbox');
var chkBoxBorderSingleStyling = $('.checkbox-border-single-styling');
var chkBoxBorderStyling = $('.checkbox-border-styling');

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
$(document).on("click", '.single-select-checkbox', function () {
	if ($(this).prop("checked")) {
		$('.single-select-checkbox').prop("checked", false);
		$('.single-select-checkbox').siblings('label').removeClass('wpforms-selected')
		$(this).siblings('label').addClass('wpforms-selected')
		$(this).prop("checked", true);
		$('.single-select-checkbox').removeAttr('required')
	}
	else {
		$('.single-select-checkbox').siblings('label').removeClass('wpforms-selected')
	}
});

$(chkBoxBorderSingleStyling).on('click', function () {
	if ($(this).prop("checked")) {
		chkBoxBorderSingleStyling.parent().parent().removeClass('wpforms-selected');
		$(this).parent().parent().addClass('wpforms-selected').fadeIn('slow');
	}
});

//$(document).on("click", '.checkbox-border-styling', function () {
//    if ($(this).find('input').prop("checked")) {
//        $(this).parent().parent().addClass('wpforms-selected').fadeIn('slow');
//    }
//    else {
//        $(this).parent().parent().removeClass('wpforms-selected');
//    }
//});

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
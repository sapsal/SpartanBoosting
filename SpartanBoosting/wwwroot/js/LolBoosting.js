$(document).ready(function () {
	$('[data-toggle="tooltip"]').tooltip({ html: true });
});
var chkBoxBorderStyling = $('.checkbox-border-styling');

//$(document).on('change click', '.checkbox-border-styling', function () {
//	debugger;
//	if (this.checked) {
//		$(this).closest('li').addClass('wpforms-selected')
//	}
//	else {
//		$(this).closest('li').removeClass('wpforms-selected')
//	}
//});
$('#type-of-service').on('change', function () {
	if (this.value == "Duo") {
		$('.type-of-duo-div').show();
		$('.type-of-duo-div').find('input').prop('required', true);
	}
	else {
		$('.type-of-duo-div').hide();
		$('.type-of-duo-div').find('input').removeAttr('required')
	}
});

$('[name="DesiredCurrentLeague"]').on('change', function () {
	if (this.value == "Master") {
		$('#master-rank-notification').show()
		$('[name="DesiredCurrentDivision"]').hide()
		$('#desired-rank-logo').hide()
	}
	else {
		$('#master-rank-notification').hide()
		$('[name="DesiredCurrentDivision"]').show()
		$('#desired-rank-logo').show()
	}
});

$(document).on("change", '[name="PaymentMethod"]', function () {
	if (this.value == "Paypal")
		$('.stripe-form').hide()
	else
		$('.stripe-form').show()
});

$('.gfield-quote').on('change', function () {
	if ($('#current-rank').val() == "Master" || $('#current-rank').val() == "Grandmaster" || $('#current-rank').val() == "Challenger") {
		var imageCurrentRank = "/img/Lol Ranks/" + $('#current-rank').val() + ".png"
		var imageDesiredRank = "/img/Lol Ranks/" + $('#desired-rank').val() + ".png"
	}
	else {
		var imageCurrentRank = "/img/Lol Ranks/" + $('#current-rank').val() + $('#current-div').val() + ".png"
		var imageDesiredRank = "/img/Lol Ranks/" + $('#desired-rank').val() + $('#desired-div').val() + ".png"
	}
	$('#current-rank-logo').attr('src', imageCurrentRank);
	$('#desired-rank-logo').attr('src', imageDesiredRank);
});

$('.gfield-quote').on('keyup change paste', function () {
	var myform = $(this.closest('form')).serialize();
	$.ajax({
		url: '/Pricing/' + $(this.closest('form')).data('pricing'),
		data: myform,
		type: 'POST',
		success: function (result) {
			if (result.success) {
				$('#pricing-hid').val(result.price.toFixed(2))
				$('#discount-hid').val(result.discountModel)
				$('#total_price').text(result.price.toFixed(2))
				$('#subtotal_price').text(result.price.toFixed(2))
			}
			
		}
	});
});

$('#submit-quote').on('click', function () {
	$('[required]:visible').each(function () {
		if (!$(this)[0].checkValidity()) {
			$('.toast').toast('show');
			$(this).addClass('field-validation-error')
		}
		else {
			$(this).removeClass('field-validation-error')
		}
	});
	if (!$("form")[0].checkValidity()) {
		return;
	}
	$.ajax({
		url: '/LolBoosting/DisplayInformationAndPayment',
		type: 'GET',
		success: function (dataofconfirm) {
			$('.gfield-pricing-quote').hide();
			$('.gfield-pricing-quote-personal-information').html(dataofconfirm)
		}
	});
});
$('#apply-coupon').on('click', function () {
	$.ajax({
		url: '/Pricing/ApplyDiscountCode',
		data: {
			DiscountCode: $('#coupon-code').val(),
			Price: $('#subtotal_price').text()
		},
		type: 'POST',
		success: function (result) {
			if (result.success) {
				$('#pricing-hid').val(result.price.toFixed(2))
				$('#total_price').text(result.price.toFixed(2))
				$('#discount_amount').text(result.discount)
				$('#apply-coupon').prop('disabled', true);
				if (result.discountModel != null) {
					$('#discountper-hid').val(result.discountModel.discountPercentage)
					$('#discountcode-hid').val(result.discountModel.discountCode)
				}
			}
		}
	});
});
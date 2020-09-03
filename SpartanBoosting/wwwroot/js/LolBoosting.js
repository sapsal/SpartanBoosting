$('#type-of-service').on('change', function () {
	if (this.value == "Duo") {
		$('#specific-roles-content').show();
	}
	else {
		$('#specific-roles-content').hide();
	}
});

$('[name="DesiredCurrentLeague"]').on('change', function () {
	if (this.value == "Master") {
		$('#master-rank-notification').show()
		$('[name="DesiredCurrentDivision"]').hide()
	}
	else {
		$('#master-rank-notification').hide()
		$('[name="DesiredCurrentDivision"]').show()
	}
});

$(document).on("change", '[name="PaymentMethod"]', function () {
	if (this.value == "Paypal")
		$('.stripe-form').hide()
	else
		$('.stripe-form').show()
});

$('.gfield-quote').on('keyup change paste', function () {
	if (this.name == "DiscountCode") {
		//ignore for apply button
		return;
	}
	var myform = $(this.closest('form')).serialize();
	$.ajax({
		url: '/Pricing/' + $(this.closest('form')).data('pricing'),
		data: myform,
		type: 'POST',
		success: function (dataofconfirm) {
			$('.ginput_total_10').text(dataofconfirm + ' €')
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
$('.apply-discount-btn').on('click', function () {
	$.ajax({
		url: '/Pricing/ApplyDiscountCode',
		data: {
			DiscountCode: $('#discount-text').val(),
			Price: $('.ginput_total_10').text()
		},
		type: 'POST',
		success: function (dataofconfirm) {
			$('.ginput_total_10').text(dataofconfirm + ' €')
			$('.apply-discount-btn').prop('disabled', true);
		}
	});
});
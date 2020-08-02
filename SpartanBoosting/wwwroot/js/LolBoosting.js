$('#type-of-service').on('change', function () {
	if (this.value == "Duo") {
		$('#specific-roles-content').show();
	}
});

$('[name ="DesiredCurrentLeague"]').on('change', function () {
	if (this.value == "Master")
		$('#master-rank-notification').show()
	else
		$('#master-rank-notification').hide()
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
			debugger;
			$('.ginput_total_10').text(dataofconfirm + ' €')
			// do something with the result
		}
	});
});

$('#submit-quote').on('click', function () {
	$.ajax({
		url: '/LolBoosting/DisplayInformationAndPayment',
		type: 'GET',
		success: function (dataofconfirm) {
			$('.gfield-pricing-quote').hide();
			$('.gfield-pricing-quote-personal-information').html(dataofconfirm)
			debugger
		}
	});
});
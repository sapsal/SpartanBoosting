$(document).on("click", '#coaching-package', function () {
	$('.ginput_total_10').text($('#coaching-package :selected').data('amount') + ' €')
});

$('#submit-quote').on('click', function () {
	$('[required]:visible').each(function () {
		if (!$(this)[0].checkValidity()) {
			$(this).addClass('field-validation-error')
			$('.toast').toast('show');
		}
		else {
			$(this).removeClass('field-validation-error')
		}
	});
	if (!$("form")[0].checkValidity()) {
		return;
	}

	var specificChampions = $.map($('#specific-champions-ul').find(':checkbox:checked'), function (n, i) {
		return n.value;
	}).join(',');
	var currentRank = $.map($('#current-rank-ul').find(':radio:checked'), function (n, i) {
		return n.value;
	}).join(',');
	$('.gfield-pricing-quote').append($('<input type="hidden" name="SpecificChampions" asp-for="SpecificChampions" />').val(specificChampions))
	$('.gfield-pricing-quote').append($('<input type="hidden" name="CurrentRank" asp-for="CurrentRank" />').val(currentRank))
	$.ajax({
		url: '/LolBoosting/DisplayInformationAndPayment',
		type: 'GET',
		success: function (dataofconfirm) {
			$('.gfield-pricing-quote').hide();
			$('.gfield-pricing-quote-personal-information').html(dataofconfirm)
		}
	});
});

$(document).on("change", '[name="PaymentMethod"]', function () {
	if (this.value == "Paypal")
		$('.stripe-form').hide()
	else
		$('.stripe-form').show()
});
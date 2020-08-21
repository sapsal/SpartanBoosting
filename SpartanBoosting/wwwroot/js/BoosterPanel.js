$(document).on("click", '.accept-job', function () {
	debugger;
	var data = $(this).data('booster-information')
	$.ajax({
		url: '/BoosterArea/AcceptBoosterJob',
		data: data,
		type: 'POST',
		success: function (dataofconfirm) {
			$('#lol-username').text(dataofconfirm.Username)
			$('#lol-password').text(dataofconfirm.Password)
			$('#lol-details-modal').modal('show');
		}
	});
});

$('#lol-details-modal').on('shown.bs.modal', function () {
})
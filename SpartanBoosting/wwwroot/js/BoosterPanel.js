$(document).on("click", '.accept-job', function () {
	var data = $(this).data('booster-information')
	$.ajax({
		url: '/BoosterArea/AcceptBoosterJob',
		data: data,
		type: 'POST',
		success: function (dataofconfirm) {
			debugger;
			$('#lol-username').text(dataofconfirm.Username)
			$('#lol-password').text(dataofconfirm.Password)
			$('#lol-details-modal').modal('show');
		}
	});
});

$('#lol-details-modal').on('shown.bs.modal', function () {
})
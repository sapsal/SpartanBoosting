$(document).on("click", '.btn-booster-permission', function () {
	var data = $(this).data('booster-id')
	var element = $(this);
	$.ajax({
		url: '/Administration/AssignUserRole',
		data: { id: data },
		context: this,
		type: 'POST',
		success: function (dataofconfirm) {
			debugger;
		}
	});
});
$(document).on("click", '.btn-booster-permission', function () {
	var data = $(this).data('booster-id')
	$.ajax({
		url: '/Administration/AssignUserBoosterRole',
		data: { id: data },
		context: this,
		type: 'POST',
		success: function (dataofconfirm) {
			$(this).hide();
		}
	});
});

$(document).ready(function () {
	RenderDT($('.users-table'))
	function RenderDT(element) {
		dataTable = $(element).DataTable({
			lengthMenu: [5, 10, 25, 50],
			"oLanguage": { "sZeroRecords": "", "sEmptyTable": "" },
			pageLength: 10,
			"bFilter": false,
			"bInfo": false,
			"bAutoWidth": false,
			// Order settings
			order: [[0, 'asc']],
			scrollX: false,
			"bLengthChange": false,
		});
	}
});
var dataTable;
$(document).on("click", '.accept-job', function () {
	var data = $(this).data('booster-information')
	var element = $(this);
	$.ajax({
		url: '/BoosterArea/AcceptBoosterJob',
		data: data,
		context: this,
		type: 'POST',
		success: function (dataofconfirm) {
			debugger;
			$('#lol-username').text(dataofconfirm.Username)
			$('#lol-password').text(dataofconfirm.Password)
			$('#lol-details-modal').modal('show');
			$(this).parent().parent().remove()
		}
	});
});
$(document).ready(function () {
	RenderDT($('.table'))
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
			scrollX: true,
			"bLengthChange": false,
		});
	}
	$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
		dataTable.columns.adjust().draw()
	})

});
$('#lol-details-modal').on('shown.bs.modal', function () {
})
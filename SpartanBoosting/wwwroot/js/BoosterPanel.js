var dataTable;
$(document).on("click", '.accept-job', function () {
	var data = $(this).data('booster-information')
	var element = $(this);
	$.ajax({
		url: '/BoosterArea/AcceptBoosterJob',
		data: { id: data },
		context: this,
		type: 'POST',
		success: function (dataofconfirm) {
			$('#lol-username').text(dataofconfirm.Username)
			$('#lol-password').text(dataofconfirm.Password)
			$('#lol-discord').text(dataofconfirm.Discord)
			$('#lol-details-modal').modal('show');
			$(this).parent().parent().remove()
		}
	});
});
$(document).on("click", '.btn-completed-job', function () {
	var data = $(this).data('booster-information')
	var element = $(this);
	$.ajax({
		url: '/BoosterArea/CompleteBoosterJob',
		data: { id: data },
		context: this,
		type: 'POST',
		success: function (dataofconfirm) {
			if (dataofconfirm) {
				$(this).parent().parent().remove()
				var numOfJobs = parseInt($("#number_of_active_jobs").text())
				$("#number_of_active_jobs").text(numOfJobs - 1)
			}
		}
	});
});
$(document).on("click", '.btn-cancel-job', function () {
	var data = $(this).data('booster-information')
	var element = $(this);
	$.ajax({
		url: '/BoosterArea/CancellBoosterJob',
		data: { id: data },
		context: this,
		type: 'POST',
		success: function (dataofconfirm) {
			if (dataofconfirm) {
				$(this).parent().parent().remove()
			}
		}
	});
});
$(document).ready(function () {
	RenderDT($('.lol-datatable'))
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
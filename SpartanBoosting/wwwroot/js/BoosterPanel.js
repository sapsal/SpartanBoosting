var dataTable;
$(document).on("click", '.accept-job', function () {
	toastr.options = {
		"closeButton": false,
		"debug": false,
		"newestOnTop": false,
		"progressBar": false,
		"positionClass": "toast-top-right",
		"preventDuplicates": false,
		"onclick": null,
		"showDuration": "1000",
		"hideDuration": "1000",
		"timeOut": "5000",
		"extendedTimeOut": "1000",
		"showEasing": "swing",
		"hideEasing": "linear",
		"showMethod": "fadeIn",
		"hideMethod": "fadeOut"
	};
	var data = $(this).data('booster-information')
	var element = $(this);
	$.ajax({
		url: '/BoosterArea/AcceptBoosterJob',
		data: { id: data },
		context: this,
		type: 'POST',
		success: function (dataofconfirm) {
			debugger;
			if (dataofconfirm.success) {
				$('#lol-username').text(dataofconfirm.username)
				$('#lol-password').text(dataofconfirm.password)
				$('#lol-discord').text(dataofconfirm.discord)
				$('#lol-details-modal').modal('show');
				$(this).parent().parent().remove()
			}
			else {

				toastr.error(dataofconfirm.message);
			}
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
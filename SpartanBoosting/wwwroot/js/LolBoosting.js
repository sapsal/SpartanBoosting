$('#type-of-service').on('change', function () {
    if (this.value == "Duo") {
        $('#specific-roles-content').show();
    }
});

$('form').on('keyup change paste', 'input, select, textarea', function () {
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
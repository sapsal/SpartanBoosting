$('#type-of-service').on('change', function () {
    if (this.value == "Duo") {
        $('#specific-roles-content').show();
    }
});
$(document).ready(function () {
    $('#custom').hide();
    if ($('#date-filter').val() == 1) {
        $('#btn-custom').attr('checked', 'checked');        
        handleDateFilterTypeSelection($('#btn-custom'))
    }

    $('input[type=radio]').change(function (s) {
        handleDateFilterTypeSelection(this);
    });
});

function handleDateFilterTypeSelection(rdButton) {
    var filterContainerId = $(rdButton).attr('data-datefilter');
    if ($(rdButton).is(':checked') && filterContainerId == 'pre-defined') {
        $(`#${filterContainerId}`).show();
        $('#custom').hide();
    }
    else if ($(rdButton).is(':checked') && filterContainerId == 'custom') {
        $(`#${filterContainerId}`).show();
        $('#pre-defined').hide();
    }
    $('#date-filter').val($(rdButton).val());
}
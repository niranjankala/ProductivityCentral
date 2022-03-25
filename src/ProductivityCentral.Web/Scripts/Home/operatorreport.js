$(document).ready(function () {
    $('#custom').hide();
    $('input[type=radio]').change(function (s) {
        var filterContainerId = $(this).attr('data-datefilter');
        if ($(this).is(':checked') && filterContainerId == 'pre-defined') {
            $(`#${filterContainerId}`).show();
            $('#custom').hide();
        }
        else if ($(this).is(':checked') && filterContainerId == 'custom'){
            $(`#${filterContainerId}`).show();
            $('#pre-defined').hide();
        }
        //if ($(this).is(':checked') && $(filterContainerId).is(':hidden')) {
        //    $(filterContainerId).show();
        //    if (filterContainerId == 'pre-defined') {
        //        $('#custom').hide();
        //    }
        //    else {
        //        $('#pre-defined').hide();
        //    }
        //}        
    });
});
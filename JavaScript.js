$(document).ready(function () {
    $('#Country').prop('disabled', false);
    $('#State').prop('disabled', false);
    $('#City').prop('disabled', false);
    LoadCountry();

    $('#Country').change(function () {
        var countryId = $(this).val();
        if (countryId > 0) {
            LoadState(countryId);
        }
        else {
            $('#State').empty();
            $('#City').empty();
            $('#State').prop('disabled', false);
            $('#City').prop('disabled', false);
            $('#State').append('<option value="">--- Select State ---</option>');
            $('#City').append('<option value="">--- Select City ---</option>');
        }
    });


    $('#State').change(function () {
        var stateId = $(this).val();
        if (stateId > 0) {
            LoadCity(stateId);
        }
        else {
            $('#City').empty();
            $('#City').prop('disabled', false);
            $('#City').append('<option value="">--- Select City ---</option>');
        }
    });
});

function LoadCountry() {
    $('#Country').empty();
    $('#State').empty();
    $('#City').empty();

    $.ajax({
        url: '/Home/GetCountry',   // ✅ lowercase keys: 'url', 'type', 'success', 'error'
        type: 'GET',
        success: function (response) {
            debugger;
            if (response && response.length > 0) {
                $('#Country').prop('disabled', false);
                $('#Country').append('<option value="">-- Select Country --</option>');
                $('#State').append('<option value="">--- Select State ---</option>');
                $('#City').append('<option value="">--- Select City ---</option>');

                $.each(response, function (i, item) {
                    $('#Country').append('<option value="' + item.countryId + '">' + item.countryName + '</option>');
                });
            } else {
                $('#Country').prop('disabled', false);
                $('#State').prop('disabled', false);
                $('#City').prop('disabled', false);
                $('#Country').append('<option value="">--- No countries available ---</option>');
                $('#State').append('<option value="">--- No states available ---</option>');
                $('#City').append('<option value="">--- No cities available ---</option>');
            }
        },
        error: function (error) {
            alert('Error loading countries.');
            console.error(error);
        }
    });
} 

function LoadState(countryId) {
    $('#State').empty();
    $('#City').empty();
    $('#City').prop('disabled', true);  // Disable city until a state is selected

    $.ajax({
        url: '/Home/GetState?id=' + countryId,
        type: 'GET',
        success: function (response) {
            debugger;
            if (response && response.length > 0) {
                $('#State').prop('disabled', false);
                $('#State').append('<option value="">--- Select State ---</option>');
                $('#City').append('<option value="">--- Select City ---</option>');

                $.each(response, function (i, item) {
                    $('#State').append('<option value="' + item.stateId + '">' + item.stateName + '</option>');
                });
            } else {
                $('#State').prop('disabled', false);
                $('#City').prop('disabled', false);
                $('#State').append('<option value="">--- No states available ---</option>');
                $('#City').append('<option value="">--- No cities available ---</option>');
            }
        },
        error: function (error) {
            alert('Error loading states.');
            console.error(error);
        }
    });
}


function LoadCity(stateId) {
    $('#City').empty();
    $('#City').prop('disabled', false);

    $.ajax({
        url: '/Home/GetCity?id=' + stateId,
        type: 'GET',
        success: function (response) {
            debugger;
            if (response && response.length > 0) {
                $('#City').prop('disabled', false);
                $('#City').append('<option value="">--- Select City ---</option>');

                $.each(response, function (i, item) {
                    $('#City').append('<option value="' + item.cityId + '">' + item.cityName + '</option>');
                });
            } else {
                $('#City').prop('disabled', false);
                $('#City').append('<option value="">--- No cities available ---</option>');
            }
        },
        error: function (error) {
            alert('Error loading countries.');
            console.error(error);
        }
    });
}



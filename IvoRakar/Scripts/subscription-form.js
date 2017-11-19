
function OnSubmitBegin() {
    $(".form-submit-button").attr('disabled', true);
    $("#loading-div").css("display", "block");
}

function OnSubmitComplete() {
    $(".alert-dismissible").fadeTo(2000, 500).slideUp(500, function () {
        $(".alert-dismissible").slideUp(500);
    });
}
$(function () {
    $('#emailInput').blur(function () {
        var emailValue = $(this).val();

        $.ajax({
            type: 'POST',
            url: '/Account/CheckEmail',
            data: { email: emailValue },
            success: function (res) {
                if (!res) {
                    $('#emailError').text("Email already exists!");
                } else {
                    $('#emailError').text("");
                }
            },
            error: function () {
                $('#emailError').text("Error checking email.");
            }
        });
    });
});

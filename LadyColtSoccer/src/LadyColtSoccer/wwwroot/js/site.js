// Write your Javascript code.

$(document).ready(function () {
    var $emailAddress = $("div.emailAddress");
    var $phoneNumber = $("div.phoneNumber");
    var $emailAddressInput = $("input#email");
    var $phoneNumberInput = $("input#phoneNumber");

    $phoneNumberInput.prop("required", true);
    $emailAddress.hide();
    $emailAddressInput.prop("required", false);

    $("input:radio[name=\"contactChoice\"]").change(function() {
        if (this.checked && this.value === "phone") {
            $phoneNumber.show();
            $phoneNumberInput.prop("required", true);
            $emailAddress.hide();
            $emailAddressInput.prop("required", false);
        } else {
            $phoneNumber.hide();
            $phoneNumberInput.prop("required", false);
            $emailAddress.show();
            $emailAddressInput.prop("required", true);
        }
    });
});
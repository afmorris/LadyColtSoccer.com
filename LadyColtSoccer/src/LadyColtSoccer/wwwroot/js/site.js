// Write your Javascript code.

$(document).ready(function () {
    var $emailAddress = $("div.emailAddress");
    var $phoneNumber = $("div.phoneNumber");
    var $emailAddressInput = $("input#email");
    var $phoneNumberInput = $("input#phoneNumber");
    var $phoneNumberRadio = $("input#contactChoice1");

    $phoneNumberRadio.prop("checked", true);

    $phoneNumberInput.prop("required", true);
    $emailAddress.hide();
    $emailAddressInput.prop("required", false);

    $("input:radio[name=\"ContactChoice\"]").change(function() {
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
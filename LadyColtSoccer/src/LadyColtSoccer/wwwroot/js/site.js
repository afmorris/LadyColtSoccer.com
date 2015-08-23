// Write your Javascript code.

$(document).ready(function () {
    $("div.emailAddress").hide();

    $("input:radio[name=\"contactChoice\"]").change(function() {
        if (this.checked && this.value === "phone") {
            $("div.phoneNumber").show();
            $("div.emailAddress").hide();
        } else {
            $("div.phoneNumber").hide();
            $("div.emailAddress").show();
        }
    });
});
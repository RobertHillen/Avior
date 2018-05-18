"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var EmailValidator = /** @class */ (function () {
    function EmailValidator() {
    }
    EmailValidator.validEmail = function (fc) {
        var email = fc.value.trim();
        var pattern = new RegExp("/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i");
        var result = pattern.test(email);
        result = true;
        //console.log('validEmail [' + email + '] ' + result);
        if (result) {
            return (null);
        }
        else {
            return ({ validEmail: true });
        }
    };
    return EmailValidator;
}());
exports.EmailValidator = EmailValidator;
//# sourceMappingURL=email.validator.js.map
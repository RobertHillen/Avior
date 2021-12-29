"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PhoneValidator = void 0;
var PhoneValidator = /** @class */ (function () {
    function PhoneValidator() {
    }
    PhoneValidator.validPhonenumber = function (fc) {
        var phone = fc.value.trim();
        var vast = new RegExp("/^(((0)[1-9]{2}[0-9][-]?[1-9][0-9]{5})|((\\+31|0|0031)[1-9][0-9][-]?[1-9][0-9]{6}))$/");
        var mobiel = new RegExp("/^(((\\+31|0|0031)6){1}[1-9]{1}[0-9]{7})$/i");
        var resultvast = vast.test(phone);
        var resultmobiel = mobiel.test(phone);
        resultvast = true;
        resultmobiel = true;
        //console.log('vast [' + phone + '] ' + resultvast);
        //console.log('mobiel [' + phone + '] ' + resultmobiel);
        if (resultvast || resultmobiel) {
            return (null);
        }
        else {
            return ({ validPhonenumber: true });
        }
    };
    return PhoneValidator;
}());
exports.PhoneValidator = PhoneValidator;
//# sourceMappingURL=phone.validator.js.map
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var DAYSOFWEEK;
(function (DAYSOFWEEK) {
    DAYSOFWEEK[DAYSOFWEEK["Sunday"] = 0] = "Sunday";
    DAYSOFWEEK[DAYSOFWEEK["Monday"] = 1] = "Monday";
    DAYSOFWEEK[DAYSOFWEEK["Tuesday"] = 2] = "Tuesday";
    DAYSOFWEEK[DAYSOFWEEK["Wednesday"] = 3] = "Wednesday";
    DAYSOFWEEK[DAYSOFWEEK["Thursday"] = 4] = "Thursday";
    DAYSOFWEEK[DAYSOFWEEK["Friday"] = 5] = "Friday";
    DAYSOFWEEK[DAYSOFWEEK["Saturday"] = 6] = "Saturday";
})(DAYSOFWEEK = exports.DAYSOFWEEK || (exports.DAYSOFWEEK = {}));
var DaysOfWeek = /** @class */ (function () {
    function DaysOfWeek() {
    }
    DaysOfWeek.get = function (dow) {
        var result = "";
        switch (dow) {
            case DAYSOFWEEK.Sunday:
                result = "zondag";
                break;
            case DAYSOFWEEK.Monday:
                result = "maandag";
                break;
            case DAYSOFWEEK.Tuesday:
                result = "dinsdag";
                break;
            case DAYSOFWEEK.Wednesday:
                result = "woensdag";
                break;
            case DAYSOFWEEK.Thursday:
                result = "donderdag";
                break;
            case DAYSOFWEEK.Friday:
                result = "vrijdag";
                break;
            case DAYSOFWEEK.Saturday:
                result = "zaterdag";
                break;
        }
        return result;
    };
    return DaysOfWeek;
}());
exports.DaysOfWeek = DaysOfWeek;
//# sourceMappingURL=dayofweek.js.map
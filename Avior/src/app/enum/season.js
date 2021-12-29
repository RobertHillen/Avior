"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Season = exports.SEASON = void 0;
var SEASON;
(function (SEASON) {
    SEASON[SEASON["S_2017_2018"] = 1] = "S_2017_2018";
    SEASON[SEASON["S_2018_2019"] = 2] = "S_2018_2019";
})(SEASON = exports.SEASON || (exports.SEASON = {}));
var Season = /** @class */ (function () {
    function Season() {
    }
    Season.get = function (s) {
        var result = "";
        switch (s) {
            case SEASON.S_2017_2018:
                result = "2017 - 2018";
                break;
            case SEASON.S_2018_2019:
                result = "2018 - 2019";
                break;
        }
        return result;
    };
    return Season;
}());
exports.Season = Season;
//# sourceMappingURL=season.js.map
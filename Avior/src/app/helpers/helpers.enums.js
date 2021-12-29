"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.HelperEnums = void 0;
var core_1 = require("@angular/core");
var season_1 = require("../enum/season");
var dayofweek_1 = require("../enum/dayofweek");
var category_1 = require("../enum/category");
var HelperEnums = /** @class */ (function () {
    function HelperEnums() {
    }
    HelperEnums.prototype.SeasonToArray = function (reverse) {
        this.array = [];
        for (var e in season_1.SEASON) {
            if (typeof season_1.SEASON[e] === 'number') {
                if (reverse) {
                    this.array.unshift({ key: season_1.SEASON[e], value: season_1.Season.get(season_1.SEASON[e]) });
                }
                else {
                    this.array.push({ key: season_1.SEASON[e], value: season_1.Season.get(season_1.SEASON[e]) });
                }
            }
        }
        this.DebugArray('SEASON:');
        return this.array;
    };
    HelperEnums.prototype.DaysOfWeekToArray = function (reverse) {
        this.array = [];
        for (var e in dayofweek_1.DAYSOFWEEK) {
            if (typeof dayofweek_1.DAYSOFWEEK[e] === 'number') {
                if (reverse) {
                    this.array.unshift({ key: dayofweek_1.DAYSOFWEEK[e], value: dayofweek_1.DaysOfWeek.get(dayofweek_1.DAYSOFWEEK[e]) });
                }
                else {
                    this.array.push({ key: dayofweek_1.DAYSOFWEEK[e], value: dayofweek_1.DaysOfWeek.get(dayofweek_1.DAYSOFWEEK[e]) });
                }
            }
        }
        this.DebugArray('DAYSOFWEEK');
        return this.array;
    };
    HelperEnums.prototype.CategoryToArray = function (reverse) {
        this.array = [];
        for (var e in category_1.CATEGORY) {
            if (typeof category_1.CATEGORY[e] === 'number') {
                if (reverse) {
                    this.array.unshift({ key: category_1.CATEGORY[e], value: category_1.Category.get(category_1.CATEGORY[e]) });
                }
                else {
                    this.array.push({ key: category_1.CATEGORY[e], value: category_1.Category.get(category_1.CATEGORY[e]) });
                }
            }
        }
        this.DebugArray('CATEGORY:');
        return this.array;
    };
    HelperEnums.prototype.DebugArray = function (logText) {
        //for (var a of this.array) {
        //    console.log(logText + ' [' + a.key + '] ' + a.value);
        //}
    };
    HelperEnums = __decorate([
        (0, core_1.Injectable)()
    ], HelperEnums);
    return HelperEnums;
}());
exports.HelperEnums = HelperEnums;
//# sourceMappingURL=helpers.enums.js.map
"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.HelperMasterData = void 0;
var core_1 = require("@angular/core");
var dayofweek_1 = require("../enum/dayofweek");
var HelperMasterData = /** @class */ (function () {
    function HelperMasterData() {
    }
    HelperMasterData.prototype.TrainingDay = function (team, nr) {
        if (nr == 1 && team.TrainingDay1 != null) {
            return dayofweek_1.DaysOfWeek.get(team.TrainingDay1) + ' ' + this.TimeToString(team.TrainingTime1) + ', ' + team.TrainingLocation1;
        }
        else if (nr == 2 && team.TrainingDay2 != null) {
            return dayofweek_1.DaysOfWeek.get(team.TrainingDay2) + ' ' + this.TimeToString(team.TrainingTime2) + ', ' + team.TrainingLocation2;
        }
        return '';
    };
    HelperMasterData.prototype.TimeToString = function (time) {
        var t = time.toString();
        return t.substr(0, t.lastIndexOf(':'));
    };
    HelperMasterData = __decorate([
        (0, core_1.Injectable)()
    ], HelperMasterData);
    return HelperMasterData;
}());
exports.HelperMasterData = HelperMasterData;
//# sourceMappingURL=helpers.masterdata.js.map
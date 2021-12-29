"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.TeamsComponent = void 0;
var core_1 = require("@angular/core");
var teams_service_1 = require("../teams.service");
var season_1 = require("../../enum/season");
var category_1 = require("../../enum/category");
var helpers_masterdata_1 = require("../../helpers/helpers.masterdata");
var TeamsComponent = /** @class */ (function () {
    function TeamsComponent(masterdataHelpers, teamsService) {
        this.masterdataHelpers = masterdataHelpers;
        this.teamsService = teamsService;
        this.toolbarMaster = "team";
        this.toolbarTitle = "Teams";
        this.toolbarIsCreate = true;
        this.messages = [];
        this.teamData = [];
    }
    TeamsComponent.prototype.ngOnInit = function () {
        this.getList();
    };
    TeamsComponent.prototype.getSeason = function (season) {
        return season_1.Season.get(season);
    };
    TeamsComponent.prototype.getCategory = function (category) {
        return category_1.Category.get(category);
    };
    TeamsComponent.prototype.getTraining = function (team, nr) {
        return this.masterdataHelpers.TrainingDay(team, nr);
    };
    TeamsComponent.prototype.getList = function () {
        var _this = this;
        this.messages = [];
        this.teamData = [];
        this.teamsService.getList()
            .subscribe(function (c) { return _this.teamData = c; }, function (errors) { return _this.handleErrors(errors); });
    };
    TeamsComponent.prototype.handleErrors = function (errors) {
        for (var _i = 0, errors_1 = errors; _i < errors_1.length; _i++) {
            var msg = errors_1[_i];
            this.messages.push(msg);
        }
    };
    TeamsComponent = __decorate([
        (0, core_1.Component)({
            selector: 'teams',
            templateUrl: './teams.component.html',
        }),
        __metadata("design:paramtypes", [helpers_masterdata_1.HelperMasterData,
            teams_service_1.TeamsService])
    ], TeamsComponent);
    return TeamsComponent;
}());
exports.TeamsComponent = TeamsComponent;
//# sourceMappingURL=teams.component.js.map
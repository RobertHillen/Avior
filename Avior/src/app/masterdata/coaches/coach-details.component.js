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
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var coaches_service_1 = require("../coaches.service");
var coachdetails_1 = require("../model/coachdetails");
var season_1 = require("../../enum/season");
var dayofweek_1 = require("../../enum/dayofweek");
var CoachDetailsComponent = /** @class */ (function () {
    function CoachDetailsComponent(route, coachService) {
        this.route = route;
        this.coachService = coachService;
        this.toolbarTitle = "Coaches / Details";
        this.toolbarIsList = true;
        this.toolbarIsEdit = true;
        this.messages = [];
    }
    CoachDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.coachdata = new coachdetails_1.CoachDetails();
        this.route.params.forEach(function (params) {
            if (params['id'] !== undefined) {
                _this.coachService.getCoachDetails(params['id'])
                    .subscribe(function (c) { return _this.coachdata = c; }, function (errors) { return _this.handleErrors(errors); });
            }
        });
    };
    CoachDetailsComponent.prototype.getDayOfWeek = function (day) {
        return dayofweek_1.DaysOfWeek.get(day);
    };
    CoachDetailsComponent.prototype.getSeason = function (season) {
        return season_1.Season.get(season);
    };
    CoachDetailsComponent.prototype.handleErrors = function (errors) {
        this.messages = [];
        console.log('errors:' + errors);
        for (var _i = 0, errors_1 = errors; _i < errors_1.length; _i++) {
            var msg = errors_1[_i];
            this.messages.push(msg);
        }
    };
    CoachDetailsComponent = __decorate([
        core_1.Component({
            templateUrl: './coach-details.component.html',
        }),
        __metadata("design:paramtypes", [router_1.ActivatedRoute,
            coaches_service_1.CoachesService])
    ], CoachDetailsComponent);
    return CoachDetailsComponent;
}());
exports.CoachDetailsComponent = CoachDetailsComponent;
//# sourceMappingURL=coach-details.component.js.map
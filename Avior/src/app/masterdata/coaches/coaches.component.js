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
exports.CoachesComponent = void 0;
var core_1 = require("@angular/core");
var coaches_service_1 = require("../coaches.service");
var season_1 = require("../../enum/season");
var CoachesComponent = /** @class */ (function () {
    function CoachesComponent(coachService) {
        this.coachService = coachService;
        this.toolbarMaster = "coach";
        this.toolbarTitle = "Coaches";
        this.toolbarIsCreate = true;
        this.messages = [];
        this.coachData = [];
    }
    CoachesComponent.prototype.ngOnInit = function () {
        this.getList();
    };
    CoachesComponent.prototype.getSeason = function (season) {
        return season_1.Season.get(season);
    };
    CoachesComponent.prototype.getList = function () {
        var _this = this;
        this.messages = [];
        this.coachData = [];
        this.coachService.getList()
            .subscribe(function (c) { return _this.coachData = c; }, function (errors) { return _this.handleErrors(errors); });
    };
    CoachesComponent.prototype.handleErrors = function (errors) {
        for (var _i = 0, errors_1 = errors; _i < errors_1.length; _i++) {
            var msg = errors_1[_i];
            this.messages.push(msg);
        }
    };
    CoachesComponent = __decorate([
        (0, core_1.Component)({
            selector: 'coachlist',
            templateUrl: './coaches.component.html',
        }),
        __metadata("design:paramtypes", [coaches_service_1.CoachesService])
    ], CoachesComponent);
    return CoachesComponent;
}());
exports.CoachesComponent = CoachesComponent;
//# sourceMappingURL=coaches.component.js.map
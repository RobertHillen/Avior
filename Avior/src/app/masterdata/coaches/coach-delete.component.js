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
var season_1 = require("../../enum/season");
var coachdetails_1 = require("../model/coachdetails");
var CoachDeleteComponent = /** @class */ (function () {
    function CoachDeleteComponent(router, route, coachService) {
        this.router = router;
        this.route = route;
        this.coachService = coachService;
        this.toolbarTitle = "Coaches / Verwijderen";
        this.toolbarIsList = true;
        this.messages = [];
    }
    CoachDeleteComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.coachdata = new coachdetails_1.CoachDetails();
        this.route.params.forEach(function (params) {
            if (params['id'] !== undefined) {
                if (params['id'] != "-1") {
                    _this.coachdata.Id = params['id'];
                    _this.coachService.getCoachDetails(params['id'])
                        .subscribe(function (c) { return _this.coachdata = c; }, function (errors) { return _this.handleErrors(errors); });
                }
            }
        });
    };
    CoachDeleteComponent.prototype.getSeason = function (season) {
        return season_1.Season.get(season);
    };
    CoachDeleteComponent.prototype.onDelete = function () {
        this.deleteData();
    };
    CoachDeleteComponent.prototype.deleteData = function () {
        var _this = this;
        var ok;
        this.coachService.deleteCoach(this.coachdata.Id)
            .subscribe(function (c) { ok = c, _this.router.navigate(['/coaches']); }, function (errors) { return _this.handleErrors(errors); });
    };
    ;
    CoachDeleteComponent.prototype.handleErrors = function (errors) {
        this.messages = [];
        for (var _i = 0, errors_1 = errors; _i < errors_1.length; _i++) {
            var msg = errors_1[_i];
            this.messages.push(msg);
        }
    };
    CoachDeleteComponent = __decorate([
        core_1.Component({
            templateUrl: './coach-delete.component.html',
        }),
        __metadata("design:paramtypes", [router_1.Router,
            router_1.ActivatedRoute,
            coaches_service_1.CoachesService])
    ], CoachDeleteComponent);
    return CoachDeleteComponent;
}());
exports.CoachDeleteComponent = CoachDeleteComponent;
//# sourceMappingURL=coach-delete.component.js.map
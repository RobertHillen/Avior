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
var forms_1 = require("@angular/forms");
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var coaches_service_1 = require("../coaches.service");
var teams_service_1 = require("../teams.service");
var coach_1 = require("../model/coach");
var season_1 = require("../../enum/season");
var CoachAddComponent = /** @class */ (function () {
    function CoachAddComponent(router, route, coachService, teamService) {
        this.router = router;
        this.route = route;
        this.coachService = coachService;
        this.teamService = teamService;
        this.toolbarTitle = "Coaches / Nieuw";
        this.toolbarIsList = true;
        this.messages = [];
    }
    CoachAddComponent.prototype.ngOnInit = function () {
        this.coachdata = new coach_1.Coach();
        this.coachform = new forms_1.FormGroup({
            Name: new forms_1.FormControl(),
            Phone: new forms_1.FormControl(),
            Email: new forms_1.FormControl(),
            Team: new forms_1.FormControl()
        });
        this.getTeamsList();
    };
    CoachAddComponent.prototype.onSubmit = function () {
        if (this.coachform.valid) {
            this.setData();
            this.saveData();
        }
    };
    CoachAddComponent.prototype.getSeason = function (season) {
        return season_1.Season.get(season);
    };
    CoachAddComponent.prototype.setData = function () {
        this.coachdata.Id = 0;
        this.coachdata.Name = this.coachform.controls.Name.value;
        this.coachdata.PhoneNumber = this.coachform.controls.Phone.value;
        this.coachdata.Email = this.coachform.controls.Email.value;
        this.coachdata.TeamId = this.coachform.controls.Team.value;
    };
    CoachAddComponent.prototype.getTeamsList = function () {
        var _this = this;
        this.teamService.getList()
            .subscribe(function (t) { return _this.teamslist = t; }, function (errors) { return _this.handleErrors(errors); });
    };
    ;
    CoachAddComponent.prototype.saveData = function () {
        var _this = this;
        var ok;
        this.coachService.addCoach(this.coachdata)
            .subscribe(function (c) { ok = c, _this.router.navigate(['/coaches']); }, function (errors) { return _this.handleErrors(errors); });
    };
    ;
    CoachAddComponent.prototype.handleErrors = function (errors) {
        this.messages = [];
        for (var _i = 0, errors_1 = errors; _i < errors_1.length; _i++) {
            var msg = errors_1[_i];
            this.messages.push(msg);
        }
    };
    CoachAddComponent = __decorate([
        core_1.Component({
            templateUrl: './coach-add.component.html',
        }),
        __metadata("design:paramtypes", [router_1.Router,
            router_1.ActivatedRoute,
            coaches_service_1.CoachesService,
            teams_service_1.TeamsService])
    ], CoachAddComponent);
    return CoachAddComponent;
}());
exports.CoachAddComponent = CoachAddComponent;
//# sourceMappingURL=coach-add.component.js.map
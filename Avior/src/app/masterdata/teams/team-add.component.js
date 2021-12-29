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
exports.TeamAddComponent = void 0;
var forms_1 = require("@angular/forms");
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var teams_service_1 = require("../teams.service");
var team_1 = require("../model/team");
var helpers_enums_1 = require("../../helpers/helpers.enums");
var TeamAddComponent = /** @class */ (function () {
    function TeamAddComponent(router, route, teamService, fb, he) {
        this.router = router;
        this.route = route;
        this.teamService = teamService;
        this.fb = fb;
        this.he = he;
        this.toolbarMaster = "team";
        this.toolbarTitle = "Teams / Nieuw";
        this.toolbarIsList = true;
        this.messages = [];
        this.validation_messages = {
            'Name': [
                { type: 'required', message: 'Naam is een verplicht veld' },
                { type: 'maxlength', message: 'De maximum lengte is 100 posities' }
            ],
            'Season': [
                { type: 'required', message: 'Seizoen is een verplicht veld' }
            ],
            'Category': [
                { type: 'required', message: 'Categorie is een verplicht veld' }
            ],
            'TrainingDay1': [
                { type: 'required', message: 'Trainingdag 1 is een verplicht veld' }
            ],
            'TrainingTime1': [
                { type: 'required', message: 'Trainingtijd 1 is een verplicht veld' }
            ],
            'TrainingLocation1': [
                { type: 'required', message: 'Traininglocatie 1 is een verplicht veld' },
                { type: 'maxlength', message: 'De maximum lengte is 50 posities' }
            ],
            'TrainingLocation2': [
                { type: 'maxlength', message: 'De maximum lengte is 50 posities' }
            ]
        };
        this.arrSeason = he.SeasonToArray(true);
        this.arrCategory = he.CategoryToArray(false);
        this.arrDaysOfWeek = he.DaysOfWeekToArray(false);
    }
    TeamAddComponent.prototype.ngOnInit = function () {
        this.teamdata = new team_1.Team();
        this.teamform = this.fb.group({
            Name: new forms_1.FormControl('', forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.maxLength(100)])),
            Season: new forms_1.FormControl(null, forms_1.Validators.required),
            Category: new forms_1.FormControl(null, forms_1.Validators.required),
            TrainingDay1: new forms_1.FormControl(null, forms_1.Validators.required),
            TrainingTime1: new forms_1.FormControl(null, forms_1.Validators.required),
            TrainingLocation1: new forms_1.FormControl('', forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.maxLength(50)])),
            TrainingDay2: new forms_1.FormControl(),
            TrainingTime2: new forms_1.FormControl(),
            TrainingLocation2: new forms_1.FormControl('', forms_1.Validators.maxLength(50))
        }, {
            updateOn: 'blur'
        });
    };
    TeamAddComponent.prototype.onSubmit = function () {
        if (this.teamform.valid) {
            this.setData();
            this.saveData();
        }
    };
    TeamAddComponent.prototype.setData = function () {
        this.teamdata.Id = 0;
        this.teamdata.Name = this.teamform.controls.Name.value;
        this.teamdata.Season = this.teamform.controls.Season.value;
        this.teamdata.Category = this.teamform.controls.Category.value;
        this.teamdata.TrainingDay1 = this.teamform.controls.TrainingDay1.value;
        this.teamdata.TrainingTime1 = this.teamform.controls.TrainingTime1.value;
        this.teamdata.TrainingLocation1 = this.teamform.controls.TrainingLocation1.value;
        this.teamdata.TrainingDay2 = this.teamform.controls.TrainingDay2.value;
        this.teamdata.TrainingTime2 = this.teamform.controls.TrainingTime2.value;
        this.teamdata.TrainingLocation2 = this.teamform.controls.TrainingLocation2.value;
    };
    TeamAddComponent.prototype.saveData = function () {
        var _this = this;
        var ok;
        this.teamService.addTeam(this.teamdata)
            .subscribe(function (c) { ok = c, _this.router.navigate(['/teams']); }, function (errors) { return _this.handleErrors(errors); });
    };
    ;
    TeamAddComponent.prototype.handleErrors = function (errors) {
        this.messages = [];
        for (var _i = 0, errors_1 = errors; _i < errors_1.length; _i++) {
            var msg = errors_1[_i];
            this.messages.push(msg);
        }
    };
    TeamAddComponent = __decorate([
        (0, core_1.Component)({
            templateUrl: './team-add.component.html'
        }),
        __metadata("design:paramtypes", [router_1.Router,
            router_1.ActivatedRoute,
            teams_service_1.TeamsService,
            forms_1.FormBuilder,
            helpers_enums_1.HelperEnums])
    ], TeamAddComponent);
    return TeamAddComponent;
}());
exports.TeamAddComponent = TeamAddComponent;
//# sourceMappingURL=team-add.component.js.map
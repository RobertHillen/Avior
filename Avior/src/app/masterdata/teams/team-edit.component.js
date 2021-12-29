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
exports.TeamEditComponent = void 0;
var forms_1 = require("@angular/forms");
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var teams_service_1 = require("../teams.service");
var team_1 = require("../model/team");
var helpers_enums_1 = require("../../helpers/helpers.enums");
var TeamEditComponent = /** @class */ (function () {
    function TeamEditComponent(router, route, teamService, fb, he) {
        this.router = router;
        this.route = route;
        this.teamService = teamService;
        this.fb = fb;
        this.he = he;
        this.toolbarMaster = "team";
        this.toolbarTitle = "Teams / Wijzigen";
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
        this.selectedCategory = 1;
        this.selectedSeason = 2;
    }
    TeamEditComponent.prototype.compareFn = function (key1, key2) {
        var k1 = '' + key1;
        var k2 = '' + key2;
        if (key1 != null && key1.constructor.name === 'array' && key1.length > 0)
            k1 = '' + key1[0];
        if (key2 != null && key2.constructor.name === 'array' && key2.length > 0)
            k2 = '' + key2[0];
        return k1 === k2;
    };
    ;
    TeamEditComponent.prototype.ngOnInit = function () {
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
        this.getData();
    };
    TeamEditComponent.prototype.onSubmit = function () {
        if (this.teamform.valid) {
            this.setData();
            this.saveData();
        }
    };
    TeamEditComponent.prototype.getData = function () {
        var _this = this;
        this.route.params.forEach(function (params) {
            if (params['id'] !== undefined) {
                _this.teamdata.Id = params['id'];
                _this.teamService.getTeam(params['id'])
                    .subscribe(function (c) { _this.teamdata = c, _this.setFields(); }, function (errors) { return _this.handleErrors(errors); });
            }
        });
    };
    ;
    TeamEditComponent.prototype.setFields = function () {
        this.teamform.setValue({
            Name: this.teamdata.Name,
            Season: this.teamdata.Season,
            Category: this.teamdata.Category,
            TrainingDay1: this.teamdata.TrainingDay1,
            TrainingTime1: this.teamdata.TrainingTime1,
            TrainingLocation1: this.teamdata.TrainingLocation1,
            TrainingDay2: this.teamdata.TrainingDay2,
            TrainingTime2: this.teamdata.TrainingTime2,
            TrainingLocation2: this.teamdata.TrainingLocation2
        });
    };
    TeamEditComponent.prototype.setData = function () {
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
    TeamEditComponent.prototype.saveData = function () {
        var _this = this;
        var ok;
        this.teamService.editTeam(this.teamdata)
            .subscribe(function (c) { ok = c, _this.router.navigate(['/teamlist']); }, function (errors) { return _this.handleErrors(errors); });
    };
    ;
    TeamEditComponent.prototype.handleErrors = function (errors) {
        this.messages = [];
        for (var _i = 0, errors_1 = errors; _i < errors_1.length; _i++) {
            var msg = errors_1[_i];
            this.messages.push(msg);
        }
    };
    TeamEditComponent = __decorate([
        (0, core_1.Component)({
            templateUrl: './team-edit.component.html'
        }),
        __metadata("design:paramtypes", [router_1.Router,
            router_1.ActivatedRoute,
            teams_service_1.TeamsService,
            forms_1.FormBuilder,
            helpers_enums_1.HelperEnums])
    ], TeamEditComponent);
    return TeamEditComponent;
}());
exports.TeamEditComponent = TeamEditComponent;
//# sourceMappingURL=team-edit.component.js.map
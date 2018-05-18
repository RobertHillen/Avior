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
var phone_validator_1 = require("../validators/phone.validator");
var email_validator_1 = require("../validators/email.validator");
var coach_1 = require("../model/coach");
var season_1 = require("../../enum/season");
var CoachEditComponent = /** @class */ (function () {
    function CoachEditComponent(router, route, coachService, teamService) {
        this.router = router;
        this.route = route;
        this.coachService = coachService;
        this.teamService = teamService;
        this.toolbarTitle = "Coaches / Wijzigen";
        this.toolbarIsList = true;
        this.messages = [];
        this.validation_messages = {
            'Name': [
                { type: 'required', message: 'Naam is een verplicht veld' },
                { type: 'maxlength', message: 'De maximum lengte is 25 posities' }
            ],
            'Phone': [
                { type: 'maxlength', message: 'De maximum lengte is 15 posities' },
                { type: 'validPhonenumber', message: 'Voer een geldig telefoon nummer in' }
            ],
            'Email': [
                { type: 'required', message: 'Email is een verplicht veld' },
                { type: 'validEmail', message: 'Voer een geldig email adres in' },
            ],
            'Team': [
                { type: 'required', message: 'Team is een verplicht veld' }
            ]
        };
    }
    CoachEditComponent.prototype.ngOnInit = function () {
        this.coachdata = new coach_1.Coach();
        this.coachform = new forms_1.FormGroup({
            Name: new forms_1.FormControl('', forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.maxLength(25)])),
            Phone: new forms_1.FormControl('', phone_validator_1.PhoneValidator.validPhonenumber),
            Email: new forms_1.FormControl('', forms_1.Validators.compose([forms_1.Validators.required, email_validator_1.EmailValidator.validEmail])),
            Team: new forms_1.FormControl(null, forms_1.Validators.required)
        }, {
            updateOn: 'blur'
        });
        this.getData();
        this.getTeamsList();
    };
    CoachEditComponent.prototype.onSubmit = function () {
        if (this.coachform.valid) {
            this.setData();
            this.saveData();
        }
    };
    CoachEditComponent.prototype.getSeason = function (season) {
        return season_1.Season.get(season);
    };
    CoachEditComponent.prototype.getData = function () {
        var _this = this;
        this.route.params.forEach(function (params) {
            if (params['id'] !== undefined) {
                _this.coachdata.Id = params['id'];
                _this.coachService.getCoach(params['id'])
                    .subscribe(function (c) { _this.coachdata = c, _this.setFields(); }, function (errors) { return _this.handleErrors(errors); });
            }
        });
    };
    ;
    CoachEditComponent.prototype.setFields = function () {
        this.coachform.setValue({
            Name: this.coachdata.Name,
            Phone: this.coachdata.PhoneNumber,
            Email: this.coachdata.Email,
            Team: this.coachdata.TeamId
        });
    };
    CoachEditComponent.prototype.setData = function () {
        this.coachdata.Name = this.coachform.controls.Name.value;
        this.coachdata.PhoneNumber = this.coachform.controls.Phone.value;
        this.coachdata.Email = this.coachform.controls.Email.value;
        this.coachdata.TeamId = this.coachform.controls.Team.value;
    };
    CoachEditComponent.prototype.saveData = function () {
        var _this = this;
        var ok;
        this.coachService.editCoach(this.coachdata)
            .subscribe(function (c) { ok = c, _this.router.navigate(['/coaches']); }, function (errors) { return _this.handleErrors(errors); });
    };
    ;
    CoachEditComponent.prototype.getTeamsList = function () {
        var _this = this;
        this.teamService.getList()
            .subscribe(function (t) { return _this.teamslist = t; }, function (errors) { return _this.handleErrors(errors); });
    };
    ;
    CoachEditComponent.prototype.handleErrors = function (errors) {
        this.messages = [];
        for (var _i = 0, errors_1 = errors; _i < errors_1.length; _i++) {
            var msg = errors_1[_i];
            this.messages.push(msg);
        }
    };
    CoachEditComponent = __decorate([
        core_1.Component({
            templateUrl: './coach-edit.component.html',
        }),
        __metadata("design:paramtypes", [router_1.Router,
            router_1.ActivatedRoute,
            coaches_service_1.CoachesService,
            teams_service_1.TeamsService])
    ], CoachEditComponent);
    return CoachEditComponent;
}());
exports.CoachEditComponent = CoachEditComponent;
//# sourceMappingURL=coach-edit.component.js.map
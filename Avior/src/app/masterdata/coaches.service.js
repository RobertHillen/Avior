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
exports.CoachesService = void 0;
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var httpOptions = { headers: new http_1.HttpHeaders({ 'Content-Type': 'application/json' }) };
var CoachesService = /** @class */ (function () {
    function CoachesService(httpclient) {
        this.httpclient = httpclient;
        this.url = "/api/coachesApi";
    }
    CoachesService.prototype.getList = function () {
        return this.httpclient.post(this.url + '/List', null, httpOptions)
            .map(function (response) { return response; })
            .catch(this.handleListErrors);
    };
    CoachesService.prototype.getCoach = function (id) {
        var args = JSON.stringify({ Id: id });
        return this.httpclient.post(this.url + '/Get', args, httpOptions)
            .map(function (response) { return response; })
            .catch(this.handleListErrors);
    };
    CoachesService.prototype.addCoach = function (coach) {
        var args = JSON.stringify(coach);
        return this.httpclient.post(this.url + '/Add', args, httpOptions)
            .map(function (response) { return response; })
            .catch(this.handleListErrors);
    };
    CoachesService.prototype.editCoach = function (coach) {
        var args = JSON.stringify(coach);
        return this.httpclient.post(this.url + '/Edit', args, httpOptions)
            .map(function (response) { return response; })
            .catch(this.handleListErrors);
    };
    CoachesService.prototype.deleteCoach = function (id) {
        var args = JSON.stringify({ Id: id });
        return this.httpclient.post(this.url + '/Delete', args, httpOptions)
            .map(function (response) { return response; })
            .catch(this.handleListErrors);
    };
    CoachesService.prototype.getCoachDetails = function (id) {
        var args = JSON.stringify({ Id: id });
        return this.httpclient.post(this.url + '/Details', args, httpOptions)
            .map(function (response) { return response; })
            .catch(this.handleListErrors);
    };
    CoachesService.prototype.handleListErrors = function (error) {
        var errors = [];
        switch (error.status) {
            case 400: // Bad Request
                var err = error.json();
                if (err.message) {
                    errors.push(err.message);
                }
                else {
                    errors.push("Een onbekende fout is opgetreden");
                }
                break;
            case 404: // Not Found
                errors.push("Er zijn geen coaches aanwezig die getoond kunnen worden");
                break;
            case 500: // Internal Error
                errors.push(error.json().exceptionMessage);
                break;
            default:
                errors.push("Status: " + error.status + " - Error Message: " + error.statusText);
                break;
        }
        ;
        console.error('Er is een fout opgetreden', errors);
        return Observable_1.Observable.throw(errors);
    };
    CoachesService = __decorate([
        (0, core_1.Injectable)(),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], CoachesService);
    return CoachesService;
}());
exports.CoachesService = CoachesService;
//# sourceMappingURL=coaches.service.js.map
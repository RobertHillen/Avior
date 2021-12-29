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
exports.TeamsService = void 0;
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var httpOptions = { headers: new http_1.HttpHeaders({ 'Content-Type': 'application/json' }) };
var TeamsService = /** @class */ (function () {
    function TeamsService(httpclient) {
        this.httpclient = httpclient;
        this.url = "/api/teamsApi";
    }
    TeamsService.prototype.getList = function () {
        return this.httpclient.post(this.url + '/GetList', null, httpOptions)
            .map(function (response) { return response; })
            .catch(this.handleListErrors);
    };
    TeamsService.prototype.getTeam = function (id) {
        var args = JSON.stringify({ Id: id });
        return this.httpclient.post(this.url + '/GetTeam', args, httpOptions)
            .map(function (response) { return response; })
            .catch(this.handleListErrors);
    };
    TeamsService.prototype.addTeam = function (team) {
        var args = JSON.stringify(team);
        return this.httpclient.post(this.url + '/Add', args, httpOptions)
            .map(function (response) { return response; })
            .catch(this.handleListErrors);
    };
    TeamsService.prototype.editTeam = function (team) {
        var args = JSON.stringify(team);
        return this.httpclient.post(this.url + '/Edit', args, httpOptions)
            .map(function (response) { return response; })
            .catch(this.handleListErrors);
    };
    TeamsService.prototype.deleteTeam = function (id) {
        var args = JSON.stringify({ Id: id });
        return this.httpclient.post(this.url + '/Delete', args, httpOptions)
            .map(function (response) { return response; })
            .catch(this.handleListErrors);
    };
    //getTeamDetails(id: number): Observable<TeamDetails> {
    //    let args = JSON.stringify({ Id: id });
    //    return this.httpclient.post(this.url + '/Details', args, httpOptions)
    //        .map(response => response)
    //        .catch(this.handleListErrors);
    //}
    TeamsService.prototype.handleListErrors = function (error) {
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
                errors.push("Er zijn geen teams aanwezig die getoond kunnen worden");
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
    TeamsService = __decorate([
        (0, core_1.Injectable)(),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], TeamsService);
    return TeamsService;
}());
exports.TeamsService = TeamsService;
//# sourceMappingURL=teams.service.js.map
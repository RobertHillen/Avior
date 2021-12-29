import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Team } from './model/team';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

@Injectable()
export class TeamsService {
    private url = "/api/teamsApi";

    constructor(private httpclient: HttpClient) { }

    getList(): Observable<Team[]> {
        return this.httpclient.post<Team[]>(this.url + '/GetList', null, httpOptions)
            .map(response => response)
            .catch(this.handleListErrors);
    }

    getTeam(id: number): Observable<Team> {
        let args = JSON.stringify({ Id: id });

        return this.httpclient.post<Team>(this.url + '/GetTeam', args, httpOptions)
            .map(response => response)
            .catch(this.handleListErrors);
    }

    addTeam(team: Team): Observable<boolean> {
        let args = JSON.stringify(team);

        return this.httpclient.post<boolean>(this.url + '/Add', args, httpOptions)
            .map(response => response)
            .catch(this.handleListErrors);
    }

    editTeam(team: Team): Observable<boolean> {
        let args = JSON.stringify(team);

        return this.httpclient.post<boolean>(this.url + '/Edit', args, httpOptions)
            .map(response => response)
            .catch(this.handleListErrors);
    }

    deleteTeam(id: number): Observable<boolean> {
        let args = JSON.stringify({ Id: id });

        return this.httpclient.post(this.url + '/Delete', args, httpOptions)
            .map(response => response)
            .catch(this.handleListErrors);
    }

    //getTeamDetails(id: number): Observable<TeamDetails> {
    //    let args = JSON.stringify({ Id: id });

    //    return this.httpclient.post(this.url + '/Details', args, httpOptions)
    //        .map(response => response)
    //        .catch(this.handleListErrors);
    //}

    private handleListErrors(error: any): Observable<any> {
        let errors: string[] = [];

        switch (error.status) {
            case 400: // Bad Request
                let err = error.json();
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
        };

        console.error('Er is een fout opgetreden', errors);

        return Observable.throw(errors);
    }
}
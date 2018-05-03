import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { Team } from './model/team';

@Injectable()
export class TeamsService {
    private url = "/api/teamsApi";

    constructor(private http: Http) { }

    getList(): Observable<Team[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.url + '/GetList', null, options)
            .map(this.extractData)
            .catch(this.handleListErrors);
    }

    getTeam(id: number): Observable<Team> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        let args = JSON.stringify({ Id: id });

        return this.http.post(this.url + '/GetTeam', args, options)
            .map(this.extractData)
            .catch(this.handleListErrors);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

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
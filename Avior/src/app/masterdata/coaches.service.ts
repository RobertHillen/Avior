import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { Coach } from './model/coach';
import { CoachDetails } from './model/coachdetails';

@Injectable()
export class CoachesService {
    private url = "/api/coachesApi";

    constructor(private http: Http) { }

    getList(): Observable<Coach[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.url + '/List', null, options)
            .map(this.extractData)
            .catch(this.handleListErrors);
    }

    getCoach(id: number): Observable<Coach> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        let args = JSON.stringify({ Id: id });

        return this.http.post(this.url + '/Get', args, options)
            .map(this.extractData)
            .catch(this.handleListErrors);
    }

    addCoach(coach: Coach): Observable<boolean> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        let args = JSON.stringify(coach);

        return this.http.post(this.url + '/Add', args, options)
            .map(this.extractData)
            .catch(this.handleListErrors);
    }

    editCoach(coach: Coach): Observable<boolean> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        let args = JSON.stringify(coach);

        return this.http.post(this.url + '/Edit', args, options)
            .map(this.extractData)
            .catch(this.handleListErrors);
    }

    deleteCoach(id: number): Observable<boolean> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        let args = JSON.stringify({ Id: id });

        return this.http.post(this.url + '/Delete', args, options)
            .map(this.extractData)
            .catch(this.handleListErrors);
    }

    getCoachDetails(id: number): Observable<CoachDetails> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        let args = JSON.stringify({ Id: id });

        return this.http.post(this.url + '/Details', args, options)
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
                errors.push("Er zijn geen coaches aanwezig die getoond kunnen worden");
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
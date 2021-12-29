import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Coach } from './model/coach';
import { CoachDetails } from './model/coachdetails';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

@Injectable()
export class CoachesService {
    private url = "/api/coachesApi";

    constructor(private httpclient: HttpClient) { }

    getList(): Observable<Coach[]> {
        return this.httpclient.post<Coach[]>(this.url + '/List', null, httpOptions)
            .map(response => response)
            .catch(this.handleListErrors);
    }

    getCoach(id: number): Observable<Coach> {
        let args = JSON.stringify({ Id: id });

        return this.httpclient.post<Coach>(this.url + '/Get', args, httpOptions)
            .map(response => response)
            .catch(this.handleListErrors);
    }

    addCoach(coach: Coach): Observable<boolean> {
        let args = JSON.stringify(coach);

        return this.httpclient.post<boolean>(this.url + '/Add', args, httpOptions)
            .map(response => response)
            .catch(this.handleListErrors);
    }

    editCoach(coach: Coach): Observable<boolean> {
        let args = JSON.stringify(coach);

        return this.httpclient.post<boolean>(this.url + '/Edit', args, httpOptions)
            .map(response => response)
            .catch(this.handleListErrors);
    }

    deleteCoach(id: number): Observable<boolean> {
        let args = JSON.stringify({ Id: id });

        return this.httpclient.post(this.url + '/Delete', args, httpOptions)
            .map(response => response)
            .catch(this.handleListErrors);
    }

    getCoachDetails(id: number): Observable<CoachDetails> {
        let args = JSON.stringify({ Id: id });

        return this.httpclient.post(this.url + '/Details', args, httpOptions)
            .map(response => response)
            .catch(this.handleListErrors);
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
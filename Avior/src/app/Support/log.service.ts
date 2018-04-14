import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { LogContent } from './log/logcontent';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class LogService {
    private url = "/api/logApi";

    constructor(private http: Http) {
    }

    getFileList(): Observable<string[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.url + '/FileList', null, options)
            .map(this.extractData)
            .catch(this.handleListErrors);
    }

    getContent(file: string, noInfo: boolean): Observable<LogContent[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let args = JSON.stringify({ fileName: file, noInfo: noInfo });

        return this.http.post(this.url + '/Content', args, options)
            .map(this.extractData)
            .catch(this.handleContentErrors);
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
                errors.push("Er zijn geen log bestanden aanwezig");
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

    private handleContentErrors(error: any): Observable<any> {
        let errors: string[] = [];

        switch (error.status) {
            case 404: // Not Found
                errors.push("Het log bestand bevat geen informatie wat getoond kan worden");
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
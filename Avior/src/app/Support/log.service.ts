import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { LogContent } from './log/logcontent';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

@Injectable()
export class LogService {
    private url = "/api/logApi";

    result: string[];

    constructor(private httpclient: HttpClient) { }

    getFileList(): Observable<string[]> {
        return this.httpclient.post<string[]>(this.url + '/FileList', null)
            .map(response => response)
            .catch(this.handleListErrors);
    }

    getContent(file: string, noInfo: boolean): Observable<LogContent[]> {
        let args = JSON.stringify({ fileName: file, noInfo: noInfo });

        return this.httpclient.post<string[]>(this.url + '/Content', args, httpOptions)
            .map(response => response)
            .catch(this.handleContentErrors);
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
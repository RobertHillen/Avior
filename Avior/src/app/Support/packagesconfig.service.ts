import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { PackagesConfigContent } from './about/packagesconfigcontent';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

@Injectable()
export class PackagesConfigService {
    private url = "/api/AboutApi";

    constructor(private httpclient: HttpClient) { }

    getPackages(): Observable<PackagesConfigContent[]> {
        return this.httpclient.post(this.url + '/PackagesList', null, httpOptions)
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
                errors.push("Er is geen packages.config bestand aanwezig");
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
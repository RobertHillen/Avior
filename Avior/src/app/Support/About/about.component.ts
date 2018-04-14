import { Component, OnInit } from '@angular/core';

import { PackagesConfigContent } from './packagesconfigcontent';
import { PackagesConfigService } from '../packagesconfig.service';

@Component({
    selector: 'about',
    templateUrl: './about.component.html',
})
export class AboutComponent implements OnInit {

    toolbarTitle: string = "Info";

    messages: string[] = [];
    content: PackagesConfigContent[] = [];

    constructor(private pcService: PackagesConfigService) { }

    ngOnInit() {
        this.getContent();
    }

    private getContent() {
        this.messages = [];
        this.content = [];

        this.pcService.getList()
            .subscribe(c => { this.content = c },
                errors => this.handleErrors(errors));
    }

    private handleErrors(errors: any) {
        this.messages = [];

        for (let msg of errors) {
            this.messages.push(msg);
        }
    }
}  
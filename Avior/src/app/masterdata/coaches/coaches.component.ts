import { Component, OnInit } from '@angular/core';

import { CoachesService } from '../coaches.service';

import { Coach } from '../model/coach';

import { Season } from '../../enum/season';

@Component({
    selector: 'coachlist',
    templateUrl: './coaches.component.html',
})
export class CoachesComponent implements OnInit {

    toolbarMaster: string = "coach";
    toolbarTitle: string = "Coaches";
    toolbarIsCreate: boolean = true;

    messages: string[] = [];
    coachData: Coach[] = [];

    constructor(private coachService: CoachesService) { }

    ngOnInit() {
        this.getList();
    }

    getSeason(season: number) {
        return Season.get(season);
    }

    private getList() {
        this.messages = [];
        this.coachData = [];

        this.coachService.getList()
            .subscribe(c => this.coachData = c,
                       errors => this.handleErrors(errors));
    }

    private handleErrors(errors: any) {
        for (let msg of errors) {
            this.messages.push(msg);
        }
    }
}  
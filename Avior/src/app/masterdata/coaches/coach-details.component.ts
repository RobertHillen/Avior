import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { CoachesService } from '../coaches.service';

import { Coach } from '../model/coach';
import { CoachDetails } from '../model/coachdetails';
import { Team } from '../model/team';
import { Player } from '../model/player';

import { Season } from '../../enum/season';
import { DaysOfWeek } from '../../enum/dayofweek';

@Component({
    templateUrl: './coach-details.component.html',
})
export class CoachDetailsComponent implements OnInit {

    toolbarTitle: string = "Coaches / Details";
    toolbarIsList: boolean = true;
    toolbarIsEdit: boolean = true;

    coachdata: CoachDetails;
    messages: string[] = [];

    constructor(
        private route: ActivatedRoute,
        private coachService: CoachesService
    ) { }

    ngOnInit() {
        this.coachdata = new CoachDetails();

        this.route.params.forEach((params: Params) => {
            if (params['id'] !== undefined) {
                this.coachService.getCoachDetails(params['id'])
                    .subscribe(c => this.coachdata = c,
                                    errors => this.handleErrors(errors)); 
            }
        });
    }

    getDayOfWeek(day: number) {
        return DaysOfWeek.get(day);
    }

    getSeason(season: number) {
        return Season.get(season);
    }

    private handleErrors(errors: any) {
        this.messages = [];
        console.log('errors:' + errors);

        for (let msg of errors) {
            this.messages.push(msg);
        }
    }
}  
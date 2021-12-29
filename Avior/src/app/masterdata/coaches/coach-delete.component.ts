import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';

import { CoachesService } from '../coaches.service';

import { Season } from '../../enum/season';

import { CoachDetails } from '../model/coachdetails';

@Component({
    templateUrl: './coach-delete.component.html',
})
export class CoachDeleteComponent implements OnInit {

    toolbarMaster: string = "coach";
    toolbarTitle: string = "Coaches / Verwijderen";
    toolbarIsList: boolean = true;

    messages: string[] = [];
    coachdata: CoachDetails;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private coachService: CoachesService
    ) { }

    ngOnInit() {
        this.coachdata = new CoachDetails();

        this.route.params.forEach((params: Params) => {
            if (params['id'] !== undefined) {
                if (params['id'] != "-1") {
                    this.coachdata.Id = params['id'];
                    this.coachService.getCoachDetails(params['id'])
                        .subscribe(c => this.coachdata = c ,
                            errors => this.handleErrors(errors));                }
            }
        });
    }

    getSeason(season: number) {
        return Season.get(season);
    }

    onDelete() {
        this.deleteData();
    }

    private deleteData() {
        let ok: boolean;

        this.coachService.deleteCoach(this.coachdata.Id)
            .subscribe(c => { ok = c, this.router.navigate(['/coaches']); },
                errors => this.handleErrors(errors));
    };

    private handleErrors(errors: any) {
        this.messages = [];

        for (let msg of errors) {
            this.messages.push(msg);
        }
    }
}  
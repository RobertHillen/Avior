import { ReactiveFormsModule, FormsModule, FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';

import { CoachesService } from '../coaches.service';
import { TeamsService } from '../teams.service';

import { Coach } from '../model/coach';
import { Team } from '../model/team';

import { Season } from '../../enum/season';

@Component({
    templateUrl: './coach-edit.component.html',
})
export class CoachEditComponent implements OnInit {

    toolbarTitle: string = "Coaches / Wijzigen";
    toolbarIsList: boolean = true;

    coachform: FormGroup; 
    coachdata: Coach;
    teamslist: Team[];

    messages: string[] = [];

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private coachService: CoachesService,
        private teamService: TeamsService
    ) { }

    ngOnInit() {
        this.coachdata = new Coach();
        this.coachform = new FormGroup({
            Name: new FormControl(),
            Phone: new FormControl(),
            Email: new FormControl(),
            Team: new FormControl()
        });

        this.getData();
        this.getTeamsList();
    }

    onSubmit() {
        if (this.coachform.valid) {
            this.setData();
            this.saveData();
        }
    }

    getSeason(season: number) {
        return Season.get(season);
    }

    private getData() {
        this.route.params.forEach((params: Params) => {
            if (params['id'] !== undefined) {
                this.coachdata.Id = params['id'];
                this.coachService.getCoach(params['id'])
                    .subscribe(c => { this.coachdata = c, this.setFields() },
                        errors => this.handleErrors(errors));
            }
        });
    };

    private setFields() {
        this.coachform.setValue({
            Name: this.coachdata.Name,
            Phone: this.coachdata.PhoneNumber,
            Email: this.coachdata.Email,
            Team: this.coachdata.TeamId
        });
    }

    private setData() {
        this.coachdata.Name = this.coachform.controls.Name.value;
        this.coachdata.PhoneNumber = this.coachform.controls.Phone.value;
        this.coachdata.Email = this.coachform.controls.Email.value;
        this.coachdata.TeamId = this.coachform.controls.Team.value;
    }

    private saveData() {
        let ok: boolean;
        this.coachService.editCoach(this.coachdata)
            .subscribe(c => { ok = c, this.router.navigate(['/coaches']); },
                       errors => this.handleErrors(errors));
    };

    private getTeamsList() {
        this.teamService.getList()
            .subscribe(t => this.teamslist = t,
                errors => this.handleErrors(errors));
    };

    private handleErrors(errors: any) {
        this.messages = [];

        for (let msg of errors) {
            this.messages.push(msg);
        }
    }
}  
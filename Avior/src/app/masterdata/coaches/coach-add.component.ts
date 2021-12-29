import { ReactiveFormsModule, FormsModule, FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';

import { CoachesService } from '../coaches.service';
import { TeamsService } from '../teams.service';

import { PhoneValidator } from '../validators/phone.validator';
import { EmailValidator } from '../validators/email.validator';

import { Coach } from '../model/coach';
import { Team } from '../model/team';

import { Season } from '../../enum/season';

@Component({
    templateUrl: './coach-add.component.html'
})
export class CoachAddComponent implements OnInit {

    toolbarMaster: string = "coach";
    toolbarTitle: string = "Coaches / Nieuw";
    toolbarIsList: boolean = true;

    coachform: FormGroup;
    coachdata: Coach;
    teamslist: Team[];

    messages: string[] = [];

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private coachService: CoachesService,
        private teamService: TeamsService,
        private fb: FormBuilder
    ) { }

    validation_messages = {
        'Name': [
            { type: 'required', message: 'Naam is een verplicht veld' },
            { type: 'maxlength', message: 'De maximum lengte is 25 posities' }
        ],
        'Phone': [
            { type: 'maxlength', message: 'De maximum lengte is 15 posities' },
            { type: 'validPhonenumber', message: 'Voer een geldig telefoon nummer in' }
        ],
        'Email': [
            { type: 'required', message: 'Email is een verplicht veld' },
            { type: 'validEmail', message: 'Voer een geldig email adres in' },
        ],
        'Team': [
            { type: 'required', message: 'Team is een verplicht veld' }
        ]
    };

    ngOnInit() {
        this.coachdata = new Coach();
        this.coachform = this.fb.group({
            Name: new FormControl('', Validators.compose([Validators.required, Validators.maxLength(25)])),
            Phone: new FormControl('', PhoneValidator.validPhonenumber),
            Email: new FormControl('', Validators.compose([Validators.required, EmailValidator.validEmail])),
            Team: new FormControl(null, Validators.required)
        }, {
            updateOn: 'blur'
        });

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

    private setData() {
        this.coachdata.Id = 0;
        this.coachdata.Name = this.coachform.controls.Name.value;
        this.coachdata.PhoneNumber = this.coachform.controls.Phone.value;
        this.coachdata.Email = this.coachform.controls.Email.value;
        this.coachdata.TeamId = this.coachform.controls.Team.value;
    }

    private getTeamsList() {
        this.teamService.getList()
            .subscribe(t => this.teamslist = t,
                errors => this.handleErrors(errors));
    };

    private saveData() {
        let ok: boolean;

        this.coachService.addCoach(this.coachdata)
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
import { ReactiveFormsModule, FormsModule, FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';

import { TeamsService } from '../teams.service';

import { Team } from '../model/team';

import { IDictionary, HelperEnums } from '../../helpers/helpers.enums';

@Component({
    templateUrl: './team-add.component.html'
})
export class TeamAddComponent implements OnInit {

    toolbarMaster: string = "team";
    toolbarTitle: string = "Teams / Nieuw";
    toolbarIsList: boolean = true;
    
    teamform: FormGroup;
    teamdata: Team;

    messages: string[] = [];

    arrSeason: IDictionary[];
    arrCategory: IDictionary[];
    arrDaysOfWeek: IDictionary[];

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private teamService: TeamsService,
        private fb: FormBuilder,
        private he: HelperEnums
    ) {
        this.arrSeason = he.SeasonToArray(true);
        this.arrCategory = he.CategoryToArray(false);
        this.arrDaysOfWeek = he.DaysOfWeekToArray(false);
    }

    validation_messages = {
        'Name': [
            { type: 'required', message: 'Naam is een verplicht veld' },
            { type: 'maxlength', message: 'De maximum lengte is 100 posities' }
        ],
        'Season': [
            { type: 'required', message: 'Seizoen is een verplicht veld' }
        ],
        'Category': [
            { type: 'required', message: 'Categorie is een verplicht veld' }
        ],
        'TrainingDay1': [
            { type: 'required', message: 'Trainingdag 1 is een verplicht veld' }
        ],
        'TrainingTime1': [
            { type: 'required', message: 'Trainingtijd 1 is een verplicht veld' }
        ],
        'TrainingLocation1': [
            { type: 'required', message: 'Traininglocatie 1 is een verplicht veld' },
            { type: 'maxlength', message: 'De maximum lengte is 50 posities' }
        ],
        'TrainingLocation2': [
            { type: 'maxlength', message: 'De maximum lengte is 50 posities' }
        ]
    };
    
    ngOnInit() {
        this.teamdata = new Team();
        this.teamform = this.fb.group({
            Name: new FormControl('', Validators.compose([Validators.required, Validators.maxLength(100)])),
            Season: new FormControl(null, Validators.required),
            Category: new FormControl(null, Validators.required),
            TrainingDay1: new FormControl(null, Validators.required),
            TrainingTime1: new FormControl(null, Validators.required),
            TrainingLocation1: new FormControl('', Validators.compose([Validators.required, Validators.maxLength(50)])),
            TrainingDay2: new FormControl(),
            TrainingTime2: new FormControl(),
            TrainingLocation2: new FormControl('', Validators.maxLength(50))
        }, {
            updateOn: 'blur'
        });
    }
    
    onSubmit() {
        if (this.teamform.valid) {
            this.setData();
            this.saveData();
        }
    }

    private setData() {
        this.teamdata.Id = 0;
        this.teamdata.Name = this.teamform.controls.Name.value;
        this.teamdata.Season = this.teamform.controls.Season.value;
        this.teamdata.Category = this.teamform.controls.Category.value;
        this.teamdata.TrainingDay1 = this.teamform.controls.TrainingDay1.value;
        this.teamdata.TrainingTime1 = this.teamform.controls.TrainingTime1.value;
        this.teamdata.TrainingLocation1 = this.teamform.controls.TrainingLocation1.value;
        this.teamdata.TrainingDay2 = this.teamform.controls.TrainingDay2.value;
        this.teamdata.TrainingTime2 = this.teamform.controls.TrainingTime2.value;
        this.teamdata.TrainingLocation2 = this.teamform.controls.TrainingLocation2.value;
    }

    private saveData() {
        let ok: boolean;

        this.teamService.addTeam(this.teamdata)
            .subscribe(c => { ok = c, this.router.navigate(['/teams']); },
                errors => this.handleErrors(errors));
    };

    private handleErrors(errors: any) {
        this.messages = [];

        for (let msg of errors) {
            this.messages.push(msg);
        }
    }
}  
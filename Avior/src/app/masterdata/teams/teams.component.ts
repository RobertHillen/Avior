import { Component, OnInit } from '@angular/core';

import { TeamsService } from '../teams.service';

import { Team } from '../model/team';

import { Season } from '../../enum/season';
import { Category } from '../../enum/category';
import { HelperMasterData } from '../../helpers/helpers.masterdata';

@Component({
    selector: 'teams',
    templateUrl: './teams.component.html',
})
export class TeamsComponent implements OnInit {

    toolbarMaster: string = "team";
    toolbarTitle: string = "Teams";
    toolbarIsCreate: boolean = true;

    messages: string[] = [];
    teamData: Team[] = [];

    constructor(
        private masterdataHelpers: HelperMasterData,
        private teamsService: TeamsService) { }

    ngOnInit() {
        this.getList();
    }

    getSeason(season: number) {
        return Season.get(season);
    }

    getCategory(category: number) {
        return Category.get(category);
    }

    getTraining(team: Team, nr: number) {
        return this.masterdataHelpers.TrainingDay(team, nr);
    }

    private getList() {
        this.messages = [];
        this.teamData = [];

        this.teamsService.getList()
            .subscribe(c => this.teamData = c,
                errors => this.handleErrors(errors));
    }

    private handleErrors(errors: any) {
        for (let msg of errors) {
            this.messages.push(msg);
        }
    }
}  
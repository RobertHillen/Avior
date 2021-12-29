import { Injectable } from '@angular/core';
import { Team } from '../masterdata/model/team';
import { DaysOfWeek } from '../enum/dayofweek';

@Injectable()
export class HelperMasterData {
    TrainingDay(team: Team, nr: number): string {
        if (nr == 1 && team.TrainingDay1 != null) {
            return DaysOfWeek.get(team.TrainingDay1) + ' ' + this.TimeToString(team.TrainingTime1) + ', ' + team.TrainingLocation1;
        } else 
        if (nr == 2 && team.TrainingDay2 != null) {
            return DaysOfWeek.get(team.TrainingDay2) + ' ' + this.TimeToString(team.TrainingTime2) + ', ' + team.TrainingLocation2;
        }
        return '';
    }

    private TimeToString(time: number): string {
        let t = time.toString();
        return t.substr(0, t.lastIndexOf(':'));
    }
}
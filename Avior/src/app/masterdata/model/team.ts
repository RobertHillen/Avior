import { SEASON } from '../../enum/season';
import { CATEGORY } from '../../enum/category';

export class Team {
    Id: number;
    Season: SEASON;
    Category: CATEGORY;
    Name: string;
    TrainingDay1: number;
    TrainingTime1: number;
    TrainingDay2: number;
    TrainingTime2: number;
}
import { Injectable } from '@angular/core';
import { Season, SEASON } from '../enum/season';
import { DaysOfWeek, DAYSOFWEEK } from '../enum/dayofweek';
import { Category, CATEGORY } from '../enum/category';

@Injectable()
export class HelperEnums {
    private array: IDictionary[];
    
    SeasonToArray(reverse: boolean): IDictionary[] {
        this.array = [];
        for (var e in SEASON) {
            if (typeof SEASON[e] === 'number') {
                if (reverse) {
                    this.array.unshift({ key: <any>SEASON[e], value: Season.get(<any>SEASON[e]) });
                } else {
                    this.array.push({ key: <any>SEASON[e], value: Season.get(<any>SEASON[e]) });
                }
            }
        }
        this.DebugArray('SEASON:');

        return this.array;
    }

    DaysOfWeekToArray(reverse: boolean): IDictionary[] {
        this.array = [];
        for (var e in DAYSOFWEEK) {
            if (typeof DAYSOFWEEK[e] === 'number') {
                if (reverse) {
                    this.array.unshift({ key: <any>DAYSOFWEEK[e], value: DaysOfWeek.get(<any>DAYSOFWEEK[e]) });
                } else {
                    this.array.push({ key: <any>DAYSOFWEEK[e], value: DaysOfWeek.get(<any>DAYSOFWEEK[e]) });
                }
            }
        }
        this.DebugArray('DAYSOFWEEK');

        return this.array;
    }

    CategoryToArray(reverse: boolean): IDictionary[] {
        this.array = [];
        for (var e in CATEGORY) {
            if (typeof CATEGORY[e] === 'number') {
                if (reverse) {
                    this.array.unshift({ key: <any>CATEGORY[e], value: Category.get(<any>CATEGORY[e]) });
                } else {
                    this.array.push({ key: <any>CATEGORY[e], value: Category.get(<any>CATEGORY[e]) });
                }
            }
        }
        this.DebugArray('CATEGORY:');

        return this.array;
    }

    private DebugArray(logText: string) {
        //for (var a of this.array) {
        //    console.log(logText + ' [' + a.key + '] ' + a.value);
        //}
    }
}

export interface IDictionary {
    key: number;
    value: string;
}
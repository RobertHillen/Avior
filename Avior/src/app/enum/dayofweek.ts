export enum DAYSOFWEEK {
    Sunday = 0,
    Monday= 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6
}

export class DaysOfWeek {

    public static get(dow: DAYSOFWEEK) {
        let result = "";

        switch (dow) {
            case DAYSOFWEEK.Sunday:
                result = "zondag"
                break;
            case DAYSOFWEEK.Monday:
                result = "maandag"
                break;
            case DAYSOFWEEK.Tuesday:
                result = "dinsdag"
                break;
            case DAYSOFWEEK.Wednesday:
                result = "woensdag"
                break;
            case DAYSOFWEEK.Thursday:
                result = "donderdag"
                break;
            case DAYSOFWEEK.Friday:
                result = "vrijdag"
                break;
            case DAYSOFWEEK.Saturday:
                result = "zaterdag"
                break;
        }

        return result;
    }
}
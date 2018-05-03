export enum SEASON {
    S_2017_2018 = 1,
    S_2018_2019 = 2
}

export class Season {

    public static get(s: SEASON) {
        let result = "";

        switch (s) {
            case SEASON.S_2017_2018:
                result = "2017 - 2018"
                break;
            case SEASON.S_2018_2019:
                result = "2018 - 2019"
                break;
        }

        return result;
    }
}
export enum CATEGORY {
    CMV = 1,
    JeugdC = 2,
    JeugdB = 3,
    JeugdA = 4
}

export class Category {

    public static get(dow: CATEGORY) {
        let result = "";

        switch (dow) {
            case CATEGORY.CMV:
                result = "CMV"
                break;
            case CATEGORY.JeugdC:
                result = "jeugd C"
                break;
            case CATEGORY.JeugdB:
                result = "jeugd B"
                break;
            case CATEGORY.JeugdA:
                result = "jeugd A"
                break;
        }

        return result;
    }
}
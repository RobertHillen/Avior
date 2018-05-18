import { FormControl } from '@angular/forms';

export class PhoneValidator {

    static validPhonenumber(fc: FormControl) {
        let phone = fc.value.trim();

        let vast = new RegExp("/^(((0)[1-9]{2}[0-9][-]?[1-9][0-9]{5})|((\\+31|0|0031)[1-9][0-9][-]?[1-9][0-9]{6}))$/");
        let mobiel = new RegExp("/^(((\\+31|0|0031)6){1}[1-9]{1}[0-9]{7})$/i");
        let resultvast = vast.test(phone);
        let resultmobiel = mobiel.test(phone);

        resultvast = true;
        resultmobiel = true;

        //console.log('vast [' + phone + '] ' + resultvast);
        //console.log('mobiel [' + phone + '] ' + resultmobiel);

        if (resultvast || resultmobiel) {
            return (null);
        } else {
            return ({ validPhonenumber: true });
        }
    }
} 
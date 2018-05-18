import { FormControl } from '@angular/forms';

export class EmailValidator {

    static validEmail(fc: FormControl) {
        let email = fc.value.trim();

        let pattern = new RegExp("/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i");
        let result = pattern.test(email);

        result = true;
        //console.log('validEmail [' + email + '] ' + result);

        if (result) {
            return (null);
        } else {
            return ({ validEmail: true });
        }
    }
} 
import { Component, Input } from '@angular/core';

@Component({
    selector: 'toolbarmasterdata',
    templateUrl: './toolbar.component.html',
})
export class ToolbarComponent {

    @Input() Title: string;
    @Input() Id: number;
    @Input() IsList: boolean;
    @Input() IsCreate: boolean;
    @Input() IsEdit: boolean;
}  
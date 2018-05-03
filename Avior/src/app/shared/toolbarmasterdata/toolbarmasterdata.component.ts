import { Component, Input } from '@angular/core';

@Component({
    selector: 'toolbarmasterdata',
    templateUrl: './toolbarmasterdata.component.html',
})
export class ToolbarMasterDataComponent {
    @Input() Title: string;
    @Input() Id: number;
    @Input() IsList: boolean;
    @Input() IsCreate: boolean;
    @Input() IsEdit: boolean;
}  
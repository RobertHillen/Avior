import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { ToolbarMasterDataComponent } from './toolbarmasterdata/toolbarmasterdata.component';

@NgModule({
    imports: [CommonModule, FormsModule, RouterModule],
    exports: [ToolbarMasterDataComponent],
    declarations: [ToolbarMasterDataComponent],
    providers: []
})
export class SharedModule { }  
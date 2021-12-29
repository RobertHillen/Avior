import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LogService } from './log.service';
import { PackagesConfigService } from './packagesconfig.service';

import { LogComponent } from './log/log.component';
import { AboutComponent } from './about/about.component';

import { SharedModule } from '../shared/shared.module';

const routes: Routes = [
    { path: 'log', component: LogComponent },
    { path: 'Log', redirectTo: 'log' },
    { path: 'about', component: AboutComponent },
    { path: 'About', redirectTo: 'about' }
];

@NgModule({
    imports: [CommonModule, FormsModule, HttpClientModule, RouterModule.forChild(routes), SharedModule],
    declarations: [LogComponent, AboutComponent],
    providers: [LogService, PackagesConfigService]
})
export class SupportModule { }  
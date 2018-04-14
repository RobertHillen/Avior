import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ToolbarComponent } from '../Shared/toolbar.component';
import { LogComponent } from './log/log.component';
import { AboutComponent } from './about/about.component';

import { LogService } from './log.service';
import { PackagesConfigService } from './packagesconfig.service';

const routes: Routes = [
    { path: 'log', component: LogComponent },
    { path: 'Log', redirectTo: 'log' },
    { path: 'about', component: AboutComponent },
    { path: 'About', redirectTo: 'about' }
];

@NgModule({
    imports: [CommonModule, FormsModule, HttpModule, RouterModule.forChild(routes)],
    declarations: [ToolbarComponent, LogComponent, AboutComponent],
    providers: [LogService, PackagesConfigService]
})
export class SupportModule { }  
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AboutComponent } from './about/about.component';
import { LogComponent } from './log/log.component';

import { LogService } from './log/log.service';

const routes: Routes = [
    { path: 'log', component: LogComponent },
    { path: 'Log', redirectTo: 'log' },
    { path: 'about', component: AboutComponent },
    { path: 'About', redirectTo: 'about' }
];

@NgModule({
    imports: [CommonModule, FormsModule, HttpModule, RouterModule.forChild(routes)],
    declarations: [LogComponent, AboutComponent],
    providers: [LogService]
})
export class SupportModule { }  
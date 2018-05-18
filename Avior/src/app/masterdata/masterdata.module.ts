import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {
    MatInputModule, MatFormFieldModule, MatButtonModule, MatSelectModule, MatCardModule,
    MatChipsModule, MatDividerModule } from '@angular/material';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SharedModule  } from '../shared/shared.module';

import { CoachesComponent } from './coaches/coaches.component';
import { CoachAddComponent } from './coaches/coach-add.component';
import { CoachEditComponent } from './coaches/coach-edit.component';
import { CoachDetailsComponent } from './coaches/coach-details.component';
import { CoachDeleteComponent } from './coaches/coach-delete.component';

import { CoachesService } from './coaches.service';
import { TeamsService } from './teams.service';

const routes: Routes = [
    { path: 'coaches', component: CoachesComponent },
    { path: 'coachadd', component: CoachAddComponent },
    { path: 'coachedit/:id', component: CoachEditComponent },
    { path: 'coachdetails/:id', component: CoachDetailsComponent },
    { path: 'coachdelete/:id', component: CoachDeleteComponent },
    { path: 'Coaches', redirectTo: 'coaches' },
];

@NgModule({
    imports: [CommonModule, ReactiveFormsModule, FormsModule, HttpModule, RouterModule.forChild(routes), SharedModule,
        MatInputModule, MatFormFieldModule, MatButtonModule, MatSelectModule, MatCardModule,
        MatChipsModule, MatDividerModule],
    declarations: [CoachesComponent, CoachAddComponent, CoachEditComponent, CoachDetailsComponent, CoachDeleteComponent],
    providers: [CoachesService, TeamsService]
})
export class MasterDataModule { }  
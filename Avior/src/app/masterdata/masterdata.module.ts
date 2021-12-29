import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatInputModule, MatFormFieldModule, MatButtonModule, MatSelectModule, MatCardModule,
         MatChipsModule, MatDividerModule } from '@angular/material';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

import { SharedModule  } from '../shared/shared.module';

import { CoachesComponent } from './coaches/coaches.component';
import { CoachAddComponent } from './coaches/coach-add.component';
import { CoachEditComponent } from './coaches/coach-edit.component';
import { CoachDetailsComponent } from './coaches/coach-details.component';
import { CoachDeleteComponent } from './coaches/coach-delete.component';
import { CoachesService } from './coaches.service';

import { TeamsComponent } from './teams/teams.component';
import { TeamAddComponent } from './teams/team-add.component';
import { TeamEditComponent } from './teams/team-edit.component';
import { TeamsService } from './teams.service';

const routes: Routes = [
    { path: 'coachlist', component: CoachesComponent },
    { path: 'coachadd', component: CoachAddComponent },
    { path: 'coachedit/:id', component: CoachEditComponent },
    { path: 'coachdetails/:id', component: CoachDetailsComponent },
    { path: 'coachdelete/:id', component: CoachDeleteComponent },
    { path: 'Coaches', redirectTo: 'coachlist' },
    { path: 'teamlist', component: TeamsComponent },
    { path: 'teamadd', component: TeamAddComponent },
    { path: 'teamedit/:id', component: TeamEditComponent },
    //{ path: 'teamdetails/:id', component: TeamDetailsComponent },
    //{ path: 'teamdelete/:id', component: TeamDeleteComponent },
    { path: 'Teams', redirectTo: 'teamlist' },
];

@NgModule({
    imports: [CommonModule, ReactiveFormsModule, FormsModule, HttpModule, RouterModule.forChild(routes), SharedModule,
        MatInputModule, MatFormFieldModule, MatButtonModule, MatSelectModule, MatCardModule,
        MatChipsModule, MatDividerModule],
    declarations: [CoachesComponent, CoachAddComponent, CoachEditComponent, CoachDetailsComponent, CoachDeleteComponent,
        TeamsComponent, TeamAddComponent, TeamEditComponent],
    providers: [CoachesService, TeamsService]
})
export class MasterDataModule { }  
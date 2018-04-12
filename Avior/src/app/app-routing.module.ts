import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';

import { SupportModule } from './support/support.module';

const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'Home', redirectTo: 'home' },
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes),
        SupportModule],
    exports: [RouterModule]
})

export class AppRoutingModule { }

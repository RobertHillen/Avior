import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MasterDataModule } from './masterdata/masterdata.module';
import { SupportModule } from './support/support.module';

import { HomeComponent } from './home/home.component';

const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'Home', redirectTo: 'home' },
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes), MasterDataModule, SupportModule],
    exports: [RouterModule]
})

export class AppRoutingModule { }

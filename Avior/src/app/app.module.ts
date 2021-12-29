import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { MasterDataModule } from './masterdata/masterdata.module';
import { SupportModule } from './support/support.module';

import { IDictionary, HelperEnums } from './helpers/helpers.enums';
import { HelperMasterData } from './helpers/helpers.masterdata';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

@NgModule({
    imports: [BrowserModule, RouterModule, FormsModule, AppRoutingModule, MasterDataModule, SupportModule, BrowserAnimationsModule],
    declarations: [AppComponent, HomeComponent],
    providers: [HelperEnums, HelperMasterData],
    bootstrap: [AppComponent]
})
export class AppModule { }

"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.MasterDataModule = void 0;
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var material_1 = require("@angular/material");
var http_1 = require("@angular/http");
var router_1 = require("@angular/router");
var shared_module_1 = require("../shared/shared.module");
var coaches_component_1 = require("./coaches/coaches.component");
var coach_add_component_1 = require("./coaches/coach-add.component");
var coach_edit_component_1 = require("./coaches/coach-edit.component");
var coach_details_component_1 = require("./coaches/coach-details.component");
var coach_delete_component_1 = require("./coaches/coach-delete.component");
var coaches_service_1 = require("./coaches.service");
var teams_component_1 = require("./teams/teams.component");
var team_add_component_1 = require("./teams/team-add.component");
var team_edit_component_1 = require("./teams/team-edit.component");
var teams_service_1 = require("./teams.service");
var routes = [
    { path: 'coachlist', component: coaches_component_1.CoachesComponent },
    { path: 'coachadd', component: coach_add_component_1.CoachAddComponent },
    { path: 'coachedit/:id', component: coach_edit_component_1.CoachEditComponent },
    { path: 'coachdetails/:id', component: coach_details_component_1.CoachDetailsComponent },
    { path: 'coachdelete/:id', component: coach_delete_component_1.CoachDeleteComponent },
    { path: 'Coaches', redirectTo: 'coachlist' },
    { path: 'teamlist', component: teams_component_1.TeamsComponent },
    { path: 'teamadd', component: team_add_component_1.TeamAddComponent },
    { path: 'teamedit/:id', component: team_edit_component_1.TeamEditComponent },
    //{ path: 'teamdetails/:id', component: TeamDetailsComponent },
    //{ path: 'teamdelete/:id', component: TeamDeleteComponent },
    { path: 'Teams', redirectTo: 'teamlist' },
];
var MasterDataModule = /** @class */ (function () {
    function MasterDataModule() {
    }
    MasterDataModule = __decorate([
        (0, core_1.NgModule)({
            imports: [common_1.CommonModule, forms_1.ReactiveFormsModule, forms_1.FormsModule, http_1.HttpModule, router_1.RouterModule.forChild(routes), shared_module_1.SharedModule,
                material_1.MatInputModule, material_1.MatFormFieldModule, material_1.MatButtonModule, material_1.MatSelectModule, material_1.MatCardModule,
                material_1.MatChipsModule, material_1.MatDividerModule],
            declarations: [coaches_component_1.CoachesComponent, coach_add_component_1.CoachAddComponent, coach_edit_component_1.CoachEditComponent, coach_details_component_1.CoachDetailsComponent, coach_delete_component_1.CoachDeleteComponent,
                teams_component_1.TeamsComponent, team_add_component_1.TeamAddComponent, team_edit_component_1.TeamEditComponent],
            providers: [coaches_service_1.CoachesService, teams_service_1.TeamsService]
        })
    ], MasterDataModule);
    return MasterDataModule;
}());
exports.MasterDataModule = MasterDataModule;
//# sourceMappingURL=masterdata.module.js.map
"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var toolbar_component_1 = require("../Shared/toolbar.component");
var log_component_1 = require("./log/log.component");
var about_component_1 = require("./about/about.component");
var log_service_1 = require("./log.service");
var packagesconfig_service_1 = require("./packagesconfig.service");
var routes = [
    { path: 'log', component: log_component_1.LogComponent },
    { path: 'Log', redirectTo: 'log' },
    { path: 'about', component: about_component_1.AboutComponent },
    { path: 'About', redirectTo: 'about' }
];
var SupportModule = /** @class */ (function () {
    function SupportModule() {
    }
    SupportModule = __decorate([
        core_1.NgModule({
            imports: [common_1.CommonModule, forms_1.FormsModule, http_1.HttpModule, router_1.RouterModule.forChild(routes)],
            declarations: [toolbar_component_1.ToolbarComponent, log_component_1.LogComponent, about_component_1.AboutComponent],
            providers: [log_service_1.LogService, packagesconfig_service_1.PackagesConfigService]
        })
    ], SupportModule);
    return SupportModule;
}());
exports.SupportModule = SupportModule;
//# sourceMappingURL=support.module.js.map
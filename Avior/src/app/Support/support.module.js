"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.SupportModule = void 0;
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/common/http");
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var log_service_1 = require("./log.service");
var packagesconfig_service_1 = require("./packagesconfig.service");
var log_component_1 = require("./log/log.component");
var about_component_1 = require("./about/about.component");
var shared_module_1 = require("../shared/shared.module");
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
        (0, core_1.NgModule)({
            imports: [common_1.CommonModule, forms_1.FormsModule, http_1.HttpClientModule, router_1.RouterModule.forChild(routes), shared_module_1.SharedModule],
            declarations: [log_component_1.LogComponent, about_component_1.AboutComponent],
            providers: [log_service_1.LogService, packagesconfig_service_1.PackagesConfigService]
        })
    ], SupportModule);
    return SupportModule;
}());
exports.SupportModule = SupportModule;
//# sourceMappingURL=support.module.js.map
"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.AboutComponent = void 0;
var core_1 = require("@angular/core");
var packagesconfig_service_1 = require("../packagesconfig.service");
var AboutComponent = /** @class */ (function () {
    function AboutComponent(pcService) {
        this.pcService = pcService;
        this.toolbarTitle = "Info";
        this.messages = [];
        this.content = [];
    }
    AboutComponent.prototype.ngOnInit = function () {
        this.getPackages();
    };
    AboutComponent.prototype.getPackages = function () {
        var _this = this;
        this.messages = [];
        this.content = [];
        this.pcService.getPackages()
            .subscribe(function (c) { _this.content = c; }, function (errors) { return _this.handleErrors(errors); });
    };
    AboutComponent.prototype.handleErrors = function (errors) {
        this.messages = [];
        for (var _i = 0, errors_1 = errors; _i < errors_1.length; _i++) {
            var msg = errors_1[_i];
            this.messages.push(msg);
        }
    };
    AboutComponent = __decorate([
        (0, core_1.Component)({
            selector: 'about',
            templateUrl: './about.component.html',
        }),
        __metadata("design:paramtypes", [packagesconfig_service_1.PackagesConfigService])
    ], AboutComponent);
    return AboutComponent;
}());
exports.AboutComponent = AboutComponent;
//# sourceMappingURL=about.component.js.map
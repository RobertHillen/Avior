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
var core_1 = require("@angular/core");
var ToolbarComponent = /** @class */ (function () {
    function ToolbarComponent() {
    }
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], ToolbarComponent.prototype, "Title", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Number)
    ], ToolbarComponent.prototype, "Id", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Boolean)
    ], ToolbarComponent.prototype, "IsList", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Boolean)
    ], ToolbarComponent.prototype, "IsCreate", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Boolean)
    ], ToolbarComponent.prototype, "IsEdit", void 0);
    ToolbarComponent = __decorate([
        core_1.Component({
            selector: 'toolbarmasterdata',
            templateUrl: './toolbar.component.html',
        })
    ], ToolbarComponent);
    return ToolbarComponent;
}());
exports.ToolbarComponent = ToolbarComponent;
//# sourceMappingURL=toolbar.component.js.map
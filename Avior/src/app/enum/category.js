"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Category = exports.CATEGORY = void 0;
var CATEGORY;
(function (CATEGORY) {
    CATEGORY[CATEGORY["CMV"] = 1] = "CMV";
    CATEGORY[CATEGORY["JeugdC"] = 2] = "JeugdC";
    CATEGORY[CATEGORY["JeugdB"] = 3] = "JeugdB";
    CATEGORY[CATEGORY["JeugdA"] = 4] = "JeugdA";
})(CATEGORY = exports.CATEGORY || (exports.CATEGORY = {}));
var Category = /** @class */ (function () {
    function Category() {
    }
    Category.get = function (dow) {
        var result = "";
        switch (dow) {
            case CATEGORY.CMV:
                result = "CMV";
                break;
            case CATEGORY.JeugdC:
                result = "jeugd C";
                break;
            case CATEGORY.JeugdB:
                result = "jeugd B";
                break;
            case CATEGORY.JeugdA:
                result = "jeugd A";
                break;
        }
        return result;
    };
    return Category;
}());
exports.Category = Category;
//# sourceMappingURL=category.js.map
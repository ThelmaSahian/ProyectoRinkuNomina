import { NgModule } from '@angular/core';
import {
    DxTextBoxModule, DxCheckBoxModule, DxSelectBoxModule,
    DxDataGridModule, DxBulletModule, DxTemplateModule,
    DxDateBoxModule, DxFileUploaderModule, DxTooltipModule,
    DxTextAreaModule,
    DevExtremeModule,
    DxTagBoxModule,
    DxAutocompleteModule,
    DxDropDownBoxModule,
    DxValidatorModule,
    DxSwitchModule,
    DxButtonGroupModule
} from 'devextreme-angular';

@NgModule({
    declarations:[],
    imports: [
        DxTextBoxModule, DxCheckBoxModule, DxSelectBoxModule,
        DxDataGridModule, DxBulletModule, DxTemplateModule,
        DxDateBoxModule, DxFileUploaderModule, DxTooltipModule,
        DxButtonGroupModule,
        DxTextAreaModule,
        DevExtremeModule,
        DxTagBoxModule,
        DxAutocompleteModule,
        DxDropDownBoxModule,
        DxValidatorModule,
        DxSwitchModule
    ],
    exports: [
        DxTextBoxModule, DxCheckBoxModule, DxSelectBoxModule,
        DxDataGridModule, DxBulletModule, DxTemplateModule,
        DxDateBoxModule, DxFileUploaderModule, DxTooltipModule,
        DxButtonGroupModule,
        DxTextAreaModule,
        DevExtremeModule,
        DxTagBoxModule,
        DxAutocompleteModule,
        DxDropDownBoxModule,
        DxValidatorModule,
        DxSwitchModule
    ]
})
export class DevextremeModule {}
import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class ChatAttachmentBase {

//#region chatAttachmentId Prop
        @prop()
        chatAttachmentId : number;
//#endregion chatAttachmentId Prop


//#region chatAttachmentType Prop
        @maxLength({value:50})
        chatAttachmentType : string;
//#endregion chatAttachmentType Prop


//#region contents Prop
        @prop()
        contents : string;
//#endregion contents Prop


//#region caption Prop
        @maxLength({value:50})
        caption : string;
//#endregion caption Prop



}
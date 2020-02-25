import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class StatusBase {

//#region statusId Prop
        @prop()
        statusId : number;
//#endregion statusId Prop


//#region userId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        userId : number;
//#endregion userId Prop


//#region statusType Prop
        @required()
        @maxLength({value:50})
        statusType : string;
//#endregion statusType Prop


//#region statusContent Prop
        @prop()
        statusContent : string;
//#endregion statusContent Prop


//#region statusCaption Prop
        @required()
        @maxLength({value:50})
        statusCaption : string;
//#endregion statusCaption Prop


//#region createdTime Prop
        @required()
        createdTime : Date;
//#endregion createdTime Prop





}
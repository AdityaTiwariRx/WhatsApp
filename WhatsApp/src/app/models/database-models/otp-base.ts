import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class OtpBase {

//#region otpId Prop
        @prop()
        otpId : number;
//#endregion otpId Prop


//#region otpCode Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        otpCode : number;
//#endregion otpCode Prop


//#region userId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        userId : number;
//#endregion userId Prop



}
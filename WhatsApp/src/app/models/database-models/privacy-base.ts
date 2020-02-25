import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class PrivacyBase {

//#region privacyId Prop
        @prop()
        privacyId : number;
//#endregion privacyId Prop


//#region photoPrivacy Prop
        @maxLength({value:50})
        photoPrivacy : string;
//#endregion photoPrivacy Prop


//#region aboutPrivacy Prop
        @maxLength({value:50})
        aboutPrivacy : string;
//#endregion aboutPrivacy Prop


//#region lastSeenPrivacy Prop
        @maxLength({value:50})
        lastSeenPrivacy : string;
//#endregion lastSeenPrivacy Prop


//#region statusPrivacy Prop
        @maxLength({value:50})
        statusPrivacy : string;
//#endregion statusPrivacy Prop


//#region userId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        userId : number;
//#endregion userId Prop



}
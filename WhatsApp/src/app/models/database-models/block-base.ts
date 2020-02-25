import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class BlockBase {

//#region blockId Prop
        @prop()
        blockId : number;
//#endregion blockId Prop


//#region userId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        userId : number;
//#endregion userId Prop


//#region blockedUserId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        blockedUserId : number;
//#endregion blockedUserId Prop





}
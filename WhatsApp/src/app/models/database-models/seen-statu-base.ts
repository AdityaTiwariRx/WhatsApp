import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class SeenStatuBase {

//#region seenStatusId Prop
        @prop()
        seenStatusId : number;
//#endregion seenStatusId Prop


//#region statusId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        statusId : number;
//#endregion statusId Prop


//#region seenTime Prop
        @required()
        seenTime : Date;
//#endregion seenTime Prop


//#region myContactId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        myContactId : number;
//#endregion myContactId Prop





}
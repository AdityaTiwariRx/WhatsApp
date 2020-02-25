import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class ChatBase {

//#region chatId Prop
        @prop()
        chatId : number;
//#endregion chatId Prop


//#region userId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        userId : number;
//#endregion userId Prop


//#region myContactId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        myContactId : number;
//#endregion myContactId Prop







}
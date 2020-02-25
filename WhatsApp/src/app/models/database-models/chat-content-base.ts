import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class ChatContentBase {

//#region chatContentId Prop
        @prop()
        chatContentId : number;
//#endregion chatContentId Prop


//#region chatMessage Prop
        @required()
        chatMessage : string;
//#endregion chatMessage Prop


//#region chatId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        chatId : number;
//#endregion chatId Prop


//#region chatAttachmentId Prop
        @prop()
        chatAttachmentId : number;
//#endregion chatAttachmentId Prop


//#region sendTime Prop
        @required()
        sendTime : Date;
//#endregion sendTime Prop


//#region receiveTime Prop
        @prop()
        receiveTime : Date;
//#endregion receiveTime Prop


//#region seenTime Prop
        @prop()
        seenTime : Date;
//#endregion seenTime Prop





}
import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class vChatBase {

//#region sender Id Prop
        @gridColumn({visible: true, columnIndex:1, allowSorting: true, headerKey: 'sender Id', keyColumn: true})
        sender Id : number;
//#endregion sender Id Prop


//#region sender name Prop
        @gridColumn({visible: true, columnIndex:2, allowSorting: true, headerKey: 'sender name', keyColumn: false})
        sender name : string;
//#endregion sender name Prop


//#region receiverId Prop
        @gridColumn({visible: true, columnIndex:3, allowSorting: true, headerKey: 'receiverId', keyColumn: false})
        receiverId : number;
//#endregion receiverId Prop


//#region receiver name Prop
        @gridColumn({visible: true, columnIndex:4, allowSorting: true, headerKey: 'receiver name', keyColumn: false})
        receiver name : string;
//#endregion receiver name Prop


//#region chatId Prop
        @gridColumn({visible: true, columnIndex:5, allowSorting: true, headerKey: 'chatId', keyColumn: false})
        chatId : number;
//#endregion chatId Prop


//#region chatMessage Prop
        @gridColumn({visible: true, columnIndex:6, allowSorting: true, headerKey: 'chatMessage', keyColumn: false})
        chatMessage : string;
//#endregion chatMessage Prop


//#region sendTime Prop
        @gridColumn({visible: true, columnIndex:7, allowSorting: true, headerKey: 'sendTime', keyColumn: false})
        sendTime : any;
//#endregion sendTime Prop

}
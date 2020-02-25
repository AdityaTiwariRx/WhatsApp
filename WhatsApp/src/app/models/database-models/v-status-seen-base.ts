import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class vStatusSeenBase {

//#region userId Prop
        @gridColumn({visible: true, columnIndex:0, allowSorting: true, headerKey: 'userId', keyColumn: true})
        userId : number;
//#endregion userId Prop


//#region statusId Prop
        @gridColumn({visible: true, columnIndex:1, allowSorting: true, headerKey: 'statusId', keyColumn: false})
        statusId : number;
//#endregion statusId Prop


//#region myContactId Prop
        @gridColumn({visible: true, columnIndex:2, allowSorting: true, headerKey: 'myContactId', keyColumn: false})
        myContactId : number;
//#endregion myContactId Prop


//#region myContactName Prop
        @gridColumn({visible: true, columnIndex:3, allowSorting: true, headerKey: 'myContactName', keyColumn: false})
        myContactName : string;
//#endregion myContactName Prop


//#region seenTime Prop
        @gridColumn({visible: true, columnIndex:4, allowSorting: true, headerKey: 'seenTime', keyColumn: false})
        seenTime : any;
//#endregion seenTime Prop

}
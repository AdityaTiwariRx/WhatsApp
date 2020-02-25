import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class MyContactBase {

//#region myContactId Prop
        @prop()
        myContactId : number;
//#endregion myContactId Prop


//#region myContactName Prop
        @required()
        @maxLength({value:50})
        myContactName : string;
//#endregion myContactName Prop


//#region userId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        userId : number;
//#endregion userId Prop


//#region usercontactId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        usercontactId : number;
//#endregion usercontactId Prop


//#region isBlocked Prop
        @required()
        isBlocked : boolean;
//#endregion isBlocked Prop









}
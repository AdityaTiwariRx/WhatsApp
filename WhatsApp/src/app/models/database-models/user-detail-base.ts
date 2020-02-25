import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class UserDetailBase {

//#region userDetailId Prop
        @prop()
        userDetailId : number;
//#endregion userDetailId Prop


//#region userName Prop
        @required()
        @maxLength({value:50})
        userName : string;
//#endregion userName Prop


//#region userPhoto Prop
        @prop()
        userPhoto : string;
//#endregion userPhoto Prop


//#region about Prop
        @maxLength({value:150})
        about : string;
//#endregion about Prop


//#region userId Prop
        @range({minimumNumber:1,maximumNumber:2147483647})
        @required()
        userId : number;
//#endregion userId Prop



}
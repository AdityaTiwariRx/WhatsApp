import {MyContactBase} from '../database-models/my-contact-base';
import {UserBase} from '../database-models/user-base';
import {ChatBase} from '../database-models/chat-base';
import {BlockBase} from '../database-models/block-base';
import {SeenStatuBase} from '../database-models/seen-statu-base';
//Generated Imports
export class MyContact extends MyContactBase 
{




//#region Generated Reference Properties
//#region user Prop
        user : UserBase;
//#endregion user Prop

//#region chats Prop
        chats : ChatBase[];
//#endregion chats Prop

//#region blocks Prop
        blocks : BlockBase[];
//#endregion blocks Prop

//#region seenStatus Prop
        seenStatus : SeenStatuBase[];
//#endregion seenStatus Prop

//#endregion Generated Reference Properties
}
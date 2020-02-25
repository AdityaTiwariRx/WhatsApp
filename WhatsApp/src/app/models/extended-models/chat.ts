import {ChatBase} from '../database-models/chat-base';
import {MyContactBase} from '../database-models/my-contact-base';
import {UserBase} from '../database-models/user-base';
import {ChatContentBase} from '../database-models/chat-content-base';
//Generated Imports
export class Chat extends ChatBase 
{




//#region Generated Reference Properties
//#region myContact Prop
        myContact : MyContactBase;
//#endregion myContact Prop

//#region user Prop
        user : UserBase;
//#endregion user Prop

//#region chatContents Prop
        chatContents : ChatContentBase[];
//#endregion chatContents Prop

//#endregion Generated Reference Properties
}
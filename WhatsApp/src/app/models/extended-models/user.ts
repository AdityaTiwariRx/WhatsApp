import {UserBase} from '../database-models/user-base';
import {CountryBase} from '../database-models/country-base';
import {StatusBase} from '../database-models/status-base';
import {UserDetailBase} from '../database-models/user-detail-base';
import {MyContactBase} from '../database-models/my-contact-base';
import {ChatBase} from '../database-models/chat-base';
import {BlockBase} from '../database-models/block-base';
import {OtpBase} from '../database-models/otp-base';
import {PrivacyBase} from '../database-models/privacy-base';
import {ApplicationUserTokenBase} from '../database-models/application-user-token-base';
import {UserRoleBase} from '../database-models/user-role-base';
//Generated Imports
export class User extends UserBase 
{




//#region Generated Reference Properties
//#region country Prop
        country : CountryBase;
//#endregion country Prop

//#region status Prop
        status : StatusBase[];
//#endregion status Prop

//#region userDetails Prop
        userDetails : UserDetailBase[];
//#endregion userDetails Prop

//#region myContacts Prop
        myContacts : MyContactBase[];
//#endregion myContacts Prop

//#region chats Prop
        chats : ChatBase[];
//#endregion chats Prop

//#region blocks Prop
        blocks : BlockBase[];
//#endregion blocks Prop

//#region otp Prop
        otp : OtpBase[];
//#endregion otp Prop

//#region privacies Prop
        privacies : PrivacyBase[];
//#endregion privacies Prop

//#region applicationUserTokens Prop
        applicationUserTokens : ApplicationUserTokenBase[];
//#endregion applicationUserTokens Prop

//#region userRoles Prop
        userRoles : UserRoleBase[];
//#endregion userRoles Prop

//#endregion Generated Reference Properties
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using WhatsApp.Models.Enums.Main;
using WhatsApp.BoundedContext.SqlContext;
namespace WhatsApp.Models.Main
{
    [Table("Chats",Schema="dbo")]
    public partial class Chat
    {
		#region ChatId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion ChatId Annotations

        public int ChatId { get; set; }

		#region UserId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("Users","dbo","","UserId")]
		#endregion UserId Annotations

        public int UserId { get; set; }

		#region MyContactId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("MyContacts","dbo","","MyContactId")]
		#endregion MyContactId Annotations

        public int MyContactId { get; set; }

		#region MyContact Annotations

        [ForeignKey(nameof(MyContactId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.MyContacts.Chats))]
		#endregion MyContact Annotations

        public virtual MyContacts MyContact { get; set; }

		#region User Annotations

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.User.Chats))]
		#endregion User Annotations

        public virtual User User { get; set; }

		#region ChatContents Annotations

        [InverseProperty("Chat")]
		#endregion ChatContents Annotations

        public virtual ICollection<ChatContent> ChatContents { get; set; }


        public Chat()
        {
			ChatContents = new HashSet<ChatContent>();
        }
	}
}
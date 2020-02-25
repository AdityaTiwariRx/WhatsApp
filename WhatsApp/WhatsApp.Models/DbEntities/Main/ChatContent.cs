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
    [Table("ChatContents",Schema="dbo")]
    public partial class ChatContent
    {
		#region ChatContentId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion ChatContentId Annotations

        public int ChatContentId { get; set; }

		#region ChatMessage Annotations

        [Required]
		#endregion ChatMessage Annotations

        public string ChatMessage { get; set; }

		#region ChatId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("Chats","dbo","","ChatId")]
		#endregion ChatId Annotations

        public int ChatId { get; set; }

		#region ChatAttachmentId Annotations

        [RelationshipTableAttribue("ChatAttachments","dbo","","ChatAttachmentId")]
		#endregion ChatAttachmentId Annotations

        public Nullable<int> ChatAttachmentId { get; set; }

		#region SendTime Annotations

        [Required]
		#endregion SendTime Annotations

        public System.DateTime SendTime { get; set; }


        public Nullable<System.DateTime> ReceiveTime { get; set; }


        public Nullable<System.DateTime> SeenTime { get; set; }

		#region ChatAttachment Annotations

        [ForeignKey(nameof(ChatAttachmentId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.ChatAttachment.ChatContents))]
		#endregion ChatAttachment Annotations

        public virtual ChatAttachment ChatAttachment { get; set; }

		#region Chat Annotations

        [ForeignKey(nameof(ChatId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.Chat.ChatContents))]
		#endregion Chat Annotations

        public virtual Chat Chat { get; set; }


        public ChatContent()
        {
        }
	}
}
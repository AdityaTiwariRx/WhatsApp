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
    [Table("ChatAttachments",Schema="dbo")]
    public partial class ChatAttachment
    {
		#region ChatAttachmentId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion ChatAttachmentId Annotations

        public int ChatAttachmentId { get; set; }

		#region ChatAttachmentType Annotations

        [MaxLength(50)]
		#endregion ChatAttachmentType Annotations

        public string ChatAttachmentType { get; set; }


        public string Contents { get; set; }

		#region Caption Annotations

        [MaxLength(50)]
		#endregion Caption Annotations

        public string Caption { get; set; }

		#region ChatContents Annotations

        [InverseProperty("ChatAttachment")]
		#endregion ChatContents Annotations

        public virtual ICollection<ChatContent> ChatContents { get; set; }


        public ChatAttachment()
        {
			ChatContents = new HashSet<ChatContent>();
        }
	}
}
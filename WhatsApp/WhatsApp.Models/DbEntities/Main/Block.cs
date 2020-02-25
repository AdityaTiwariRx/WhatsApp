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
    [Table("Blocks",Schema="dbo")]
    public partial class Block
    {
		#region BlockId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion BlockId Annotations

        public int BlockId { get; set; }

		#region UserId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("Users","dbo","","UserId")]
		#endregion UserId Annotations

        public int UserId { get; set; }

		#region BlockedUserId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("MyContacts","dbo","","BlockedUserId")]
		#endregion BlockedUserId Annotations

        public int BlockedUserId { get; set; }

		#region MyContact Annotations

        [ForeignKey(nameof(BlockedUserId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.MyContact.Blocks))]
		#endregion MyContact Annotations

        public virtual MyContact MyContact { get; set; }

		#region User Annotations

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.User.Blocks))]
		#endregion User Annotations

        public virtual User User { get; set; }


        public Block()
        {
        }
	}
}
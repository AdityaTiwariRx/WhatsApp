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
    [Table("MyContacts",Schema="dbo")]
    public partial class MyContact
    {
		#region MyContactId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion MyContactId Annotations

        public int MyContactId { get; set; }

		#region MyContactName Annotations

        [Required]
        [MaxLength(50)]
		#endregion MyContactName Annotations

        public string MyContactName { get; set; }

		#region UserId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("Users","dbo","","UserId")]
		#endregion UserId Annotations

        public int UserId { get; set; }

		#region UsercontactId Annotations

        [Range(1,int.MaxValue)]
        [Required]
		#endregion UsercontactId Annotations

        public int UsercontactId { get; set; }

		#region IsBlocked Annotations

        [Required]
		#endregion IsBlocked Annotations

        public bool IsBlocked { get; set; }

		#region User Annotations

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.User.MyContacts))]
		#endregion User Annotations

        public virtual User User { get; set; }

		#region Chats Annotations

        [InverseProperty("MyContact")]
		#endregion Chats Annotations

        public virtual ICollection<Chat> Chats { get; set; }

		#region Blocks Annotations

        [InverseProperty("MyContact")]
		#endregion Blocks Annotations

        public virtual ICollection<Block> Blocks { get; set; }

		#region SeenStatus Annotations

        [InverseProperty("MyContact")]
		#endregion SeenStatus Annotations

        public virtual ICollection<SeenStatu> SeenStatus { get; set; }


        public MyContact()
        {
			Chats = new HashSet<Chat>();
			Blocks = new HashSet<Block>();
			SeenStatus = new HashSet<SeenStatu>();
        }
	}
}
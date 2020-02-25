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
    [Table("SeenStatus",Schema="dbo")]
    public partial class SeenStatu
    {
		#region SeenStatusId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion SeenStatusId Annotations

        public int SeenStatusId { get; set; }

		#region StatusId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("Status","dbo","","StatusId")]
		#endregion StatusId Annotations

        public int StatusId { get; set; }

		#region SeenTime Annotations

        [Required]
		#endregion SeenTime Annotations

        public System.DateTime SeenTime { get; set; }

		#region MyContactId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("MyContacts","dbo","","MyContactId")]
		#endregion MyContactId Annotations

        public int MyContactId { get; set; }

		#region MyContact Annotations

        [ForeignKey(nameof(MyContactId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.MyContact.SeenStatus))]
		#endregion MyContact Annotations

        public virtual MyContact MyContact { get; set; }

		#region Status Annotations

        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.Status.SeenStatus))]
		#endregion Status Annotations

        public virtual Status Status { get; set; }


        public SeenStatu()
        {
        }
	}
}
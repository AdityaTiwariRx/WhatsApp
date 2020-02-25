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
    [Table("Status",Schema="dbo")]
    public partial class Status
    {
		#region StatusId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion StatusId Annotations

        public int StatusId { get; set; }

		#region UserId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("Users","dbo","","UserId")]
		#endregion UserId Annotations

        public int UserId { get; set; }

		#region StatusType Annotations

        [Required]
        [MaxLength(50)]
		#endregion StatusType Annotations

        public string StatusType { get; set; }


        public string StatusContent { get; set; }

		#region StatusCaption Annotations

        [Required]
        [MaxLength(50)]
		#endregion StatusCaption Annotations

        public string StatusCaption { get; set; }

		#region CreatedTime Annotations

        [Required]
		#endregion CreatedTime Annotations

        public System.DateTime CreatedTime { get; set; }

		#region User Annotations

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.User.Status))]
		#endregion User Annotations

        public virtual User User { get; set; }

		#region SeenStatus Annotations

        [InverseProperty("Status")]
		#endregion SeenStatus Annotations

        public virtual ICollection<SeenStatu> SeenStatus { get; set; }


        public Status()
        {
			SeenStatus = new HashSet<SeenStatu>();
        }
	}
}
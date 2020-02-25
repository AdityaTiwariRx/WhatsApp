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
    [Table("UserDetails",Schema="dbo")]
    public partial class UserDetail
    {
		#region UserDetailId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion UserDetailId Annotations

        public int UserDetailId { get; set; }

		#region UserName Annotations

        [Required]
        [MaxLength(50)]
		#endregion UserName Annotations

        public string UserName { get; set; }


        public string UserPhoto { get; set; }

		#region About Annotations

        [MaxLength(150)]
		#endregion About Annotations

        public string About { get; set; }

		#region UserId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("Users","dbo","","UserId")]
		#endregion UserId Annotations

        public int UserId { get; set; }

		#region User Annotations

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.User.UserDetails))]
		#endregion User Annotations

        public virtual User User { get; set; }


        public UserDetail()
        {
        }
	}
}
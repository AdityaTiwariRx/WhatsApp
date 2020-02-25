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
    [Table("Otp",Schema="dbo")]
    public partial class OtpUser
    {
		#region OtpId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion OtpId Annotations

        public int OtpId { get; set; }

		#region OtpCode Annotations

        [Range(1,int.MaxValue)]
        [Required]
		#endregion OtpCode Annotations

        public int OtpCode { get; set; }

		#region UserId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("Users","dbo","","UserId")]
		#endregion UserId Annotations

        public int UserId { get; set; }

		#region User Annotations

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.User.Otp))]
		#endregion User Annotations

        public virtual User User { get; set; }


        public OtpUser()
        {
        }
	}
}
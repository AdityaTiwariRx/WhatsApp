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
    [Table("Privacies",Schema="dbo")]
    public partial class Privacy
    {
		#region PrivacyId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion PrivacyId Annotations

        public int PrivacyId { get; set; }

		#region PhotoPrivacy Annotations

        [MaxLength(50)]
		#endregion PhotoPrivacy Annotations

        public string PhotoPrivacy { get; set; }

		#region AboutPrivacy Annotations

        [MaxLength(50)]
		#endregion AboutPrivacy Annotations

        public string AboutPrivacy { get; set; }

		#region LastSeenPrivacy Annotations

        [MaxLength(50)]
		#endregion LastSeenPrivacy Annotations

        public string LastSeenPrivacy { get; set; }

		#region StatusPrivacy Annotations

        [MaxLength(50)]
		#endregion StatusPrivacy Annotations

        public string StatusPrivacy { get; set; }

		#region UserId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("Users","dbo","","UserId")]
		#endregion UserId Annotations

        public int UserId { get; set; }

		#region User Annotations

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.User.Privacies))]
		#endregion User Annotations

        public virtual User User { get; set; }


        public Privacy()
        {
        }
	}
}
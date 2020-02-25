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
    [Table("Countries",Schema="dbo")]
    public partial class Country
    {
		#region CountryId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion CountryId Annotations

        public int CountryId { get; set; }

		#region CountryCode Annotations

        [Required]
        [MaxLength(50)]
		#endregion CountryCode Annotations

        public string CountryCode { get; set; }

		#region CountryName Annotations

        [Required]
        [MaxLength(50)]
		#endregion CountryName Annotations

        public string CountryName { get; set; }

		#region Users Annotations

        [InverseProperty("Country")]
		#endregion Users Annotations

        public virtual ICollection<User> Users { get; set; }


        public Country()
        {
			Users = new HashSet<User>();
        }
	}
}
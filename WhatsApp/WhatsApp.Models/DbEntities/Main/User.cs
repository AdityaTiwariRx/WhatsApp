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
    [Table("Users",Schema="dbo")]
    public partial class User
    {
		#region UserId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion UserId Annotations

        public int UserId { get; set; }

		#region ApplicationLocaleId Annotations

        [Range(1, int.MaxValue)]
        
		#endregion ApplicationLocaleId Annotations

        public int ApplicationLocaleId { get; set; }

		#region ApplicationTimeZoneId Annotations

        [Range(1, int.MaxValue)]
        
		#endregion ApplicationTimeZoneId Annotations

        public int ApplicationTimeZoneId { get; set; }

		#region LanguageCode Annotations

        
        [MaxLength(3)]
		#endregion LanguageCode Annotations

        public string LanguageCode { get; set; }

		#region UserName Annotations

        [Required]
        [MaxLength(50)]
		#endregion UserName Annotations

        public string UserName { get; set; }

		#region Password Annotations

        
        [MaxLength(132)]
		#endregion Password Annotations

        public byte[] Password { get; set; }
       
        #region Salt Annotations

        
        [MaxLength(140)]
		#endregion Salt Annotations

        public byte[] Salt { get; set; }

		#region LoginBlocked Annotations

        
		#endregion LoginBlocked Annotations

        public bool LoginBlocked { get; set; }

		#region StatusId Annotations

        [Range(1, int.MaxValue)]
        
		#endregion StatusId Annotations

        public Status StatusId { get; set; }

		#region UserMobileNumber Annotations

        [Required]
		#endregion UserMobileNumber Annotations

        public long UserMobileNumber { get; set; }

		#region CountryId Annotations

        [Range(1,int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("Countries","dbo","","CountryId")]
		#endregion CountryId Annotations

        public int CountryId { get; set; }

		#region Country Annotations

        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(WhatsApp.Models.Main.Country.Users))]
		#endregion Country Annotations

        public virtual Country Country { get; set; }

		#region Status Annotations

        [InverseProperty("User")]
		#endregion Status Annotations

        public virtual ICollection<Status> Status { get; set; }

		#region UserDetails Annotations

        [InverseProperty("User")]
		#endregion UserDetails Annotations

        public virtual ICollection<UserDetail> UserDetails { get; set; }

		#region MyContacts Annotations

        [InverseProperty("User")]
		#endregion MyContacts Annotations

        public virtual ICollection<MyContacts> MyContacts { get; set; }

		#region Chats Annotations

        [InverseProperty("User")]
		#endregion Chats Annotations

        public virtual ICollection<Chat> Chats { get; set; }

		#region Blocks Annotations

        [InverseProperty("User")]
		#endregion Blocks Annotations

        public virtual ICollection<Block> Blocks { get; set; }

		#region Otp Annotations

        [InverseProperty("User")]
		#endregion Otp Annotations

        public virtual ICollection<Otp> Otp { get; set; }

		#region Privacies Annotations

        [InverseProperty("User")]
		#endregion Privacies Annotations

        public virtual ICollection<Privacy> Privacies { get; set; }

		#region ApplicationUserTokens Annotations

        [InverseProperty("User")]
		#endregion ApplicationUserTokens Annotations

        public virtual ICollection<ApplicationUserToken> ApplicationUserTokens { get; set; }

		#region UserRoles Annotations

        [InverseProperty("User")]
		#endregion UserRoles Annotations

        public virtual ICollection<UserRole> UserRoles { get; set; }


        public User()
        {
			Status = new HashSet<Status>();
			UserDetails = new HashSet<UserDetail>();
			MyContacts = new HashSet<MyContacts>();
			Chats = new HashSet<Chat>();
			Blocks = new HashSet<Block>();
			Otp = new HashSet<Otp>();
			Privacies = new HashSet<Privacy>();
			ApplicationUserTokens = new HashSet<ApplicationUserToken>();
			UserRoles = new HashSet<UserRole>();
        }
	}
}
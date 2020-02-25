using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using WhatsApp.BoundedContext.SqlContext;
namespace WhatsApp.Models.Main
{
    [Table("vStatusSeen",Schema="dbo")]
    public partial class vStatusSeen
    {
		#region UserId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion UserId Annotations

        public int UserId { get; set; }


        public int StatusId { get; set; }


        public int MyContactId { get; set; }


        public string MyContactName { get; set; }


        public System.DateTime SeenTime { get; set; }


        public vStatusSeen()
        {
        }
	}
}
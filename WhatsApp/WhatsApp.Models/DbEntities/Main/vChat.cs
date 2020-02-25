using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using WhatsApp.BoundedContext.SqlContext;
namespace WhatsApp.Models.Main
{
    [Table("vChats",Schema="dbo")]
    public partial class vChat
    {
		#region Sender Id Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion Sender Id Annotations

        public int SenderId { get; set; }


        public string Sendername { get; set; }


        public int ReceiverId { get; set; }


        public string Receivername { get; set; }


        public int ChatId { get; set; }


        public string ChatMessage { get; set; }


        public System.DateTime SendTime { get; set; }


        public vChat()
        {
        }
	}
}
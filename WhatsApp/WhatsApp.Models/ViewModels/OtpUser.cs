using System;
using System.Collections.Generic;
using System.Text;
using WhatsApp.Models.Main;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using WhatsApp.Models.Enums.Main;
using WhatsApp.BoundedContext.SqlContext;

namespace WhatsApp.Models.ViewModels
{
    class OtpUser : User
    {
       

        #region OtpCode Annotations

        [Range(1, int.MaxValue)]
        [Required]
        #endregion OtpCode Annotations

        public int OtpCode { get; set; }

        #region UserId Annotations

        [Range(1, int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("Users", "dbo", "", "UserId")]
        #endregion UserId Annotations

        public new int UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WhatsApp.Models.Main;

namespace WhatsApp.Models.ViewModels
{
     public class BlockedNumber : MyContact
    {
        public int BlockedUserId { get; set; }

        public new int UserId { get; set; }

    }
}

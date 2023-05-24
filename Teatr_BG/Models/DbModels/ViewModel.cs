using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Teatr_BG.Models.DbModels
{
    public class ViewModel
    {
        
        public int TotalClients { get; set; }
        public int TotalTicketsSold { get; set; }
        
    }
}
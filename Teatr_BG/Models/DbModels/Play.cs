using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Teatr_BG.Models.DbModels
{
    public class Play
    {
        [Key]
        public int PlayID { get; set; }
        public string NameP { get; set; }
        public DateTime DateP { get; set; }
        public decimal Price { get; set; }
    }
}
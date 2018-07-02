using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TTTH.DataBase.Schema
{
    [Table("Photos")]
    public class Photos : TableHaveLang
    {
        [StringLength(255)]
        public string Link { set; get; }
        [StringLength(500)]
        public string Note { set; get; }
    }
}
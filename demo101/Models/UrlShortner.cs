using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demo101.Models
{
    [Table("af_tbl_telemedicine_short_url")]
    public class UrlShortner
    {
        [Key]
        public long id { set; get; }
        public string long_url { set; get; }
        public string short_url { set; get; }
        public string token { set; get; }
        public long clicked { set; get; }
        public string created_by { set; get; }
        public DateTime? created_date { set; get; }
        public string modfied_by { set; get; }
        public DateTime? modified_date { set; get; }
        public bool deleted { set; get; }
    }
}
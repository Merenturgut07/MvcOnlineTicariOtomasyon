using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class Admin
	{
        [Key]
        public int AdminId { get; set; }

		[StringLength(15)]
		public string KullaniciAd { get; set; }

		[StringLength(15)]
		public string Sifre { get; set; }

		[StringLength(1)]
		public string Yetki { get; set; }
    }
}
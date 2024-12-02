using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class KargoTakip
	{
        [Key]
        public int KargoTakipId { get; set; }

        [StringLength(10)]
        public string TakipKodu { get; set; }

		[StringLength(200)]
		public string Aciklama { get; set; }
        public DateTime TarihZaman { get; set; }
    }
}
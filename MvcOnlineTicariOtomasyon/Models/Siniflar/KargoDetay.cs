using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class KargoDetay
	{
        [Key]
        public int KargoDetayId { get; set; }

		[StringLength(400)]
		public string Aciklama { get; set; }

		[StringLength(10)]
		public string TakipKodu { get; set; }

		[StringLength(25)]
		public string Personel { get; set; }

		[StringLength(20)]
		public string Alıcı { get; set; }
        public DateTime Tarih { get; set; }
    }
}
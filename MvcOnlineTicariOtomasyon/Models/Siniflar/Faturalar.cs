using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class Faturalar
	{
		[Key] 
        public int FaturaId { get; set; }


		[StringLength(1)]
		public string FaturaSeriNo { get; set; }


		[StringLength(6)]
		public string FaturaSıraNO { get; set; }

        public DateTime Tarih { get; set; }

		[StringLength(60)]
		public string VergiDairesi { get; set; }

		[StringLength(5)]
		public string Saat { get; set; }
        public decimal Toplam { get; set; }

		[StringLength(30)]
		public string TeslimEden { get; set; }

		[StringLength(30)]
		public string TeslimAlan { get; set; } 

        public ICollection<FaturaKalem> faturaKalems { get; set; }
    }
}
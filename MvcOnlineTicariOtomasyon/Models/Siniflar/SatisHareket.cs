﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class SatisHareket
	{
		[Key]
		public int SatisHareketId { get; set; }
		public DateTime Tarih { get; set; }
		public int Adet { get; set; }
		public decimal Fiyat { get; set; }
		public decimal ToplamTutar { get; set; }


		public int UrunId { get; set; }
		public virtual Urunler urunler { get; set; }

		public int CariId { get; set; }
		public virtual Cariler cariler { get; set; }

		public int PersonelId { get; set; }
		public virtual Personel personel { get; set; }

	}
}
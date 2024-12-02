using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class Urunler
	{
        [Key]
        public int UrunId { get; set; }

        [StringLength(30)]
        public string UrunAd { get; set; }

		[StringLength(30)]
		public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }

		[StringLength(250)]
		public string UrunGorsel { get; set; }

		public int KategoriId { get; set; }
		public virtual Kategori kategori { get; set; }

		public ICollection<SatisHareket> satisHarekets { get; set; }
	}
}
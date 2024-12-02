using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class Personel
	{
        [Key]
        public int PersonelId { get; set; }


		
		[StringLength(30)]
		public string PersonelAd { get; set; }

		[StringLength(30)]
		public string PersonelSoyad { get; set; }

		[StringLength(250)]
		public string PersonelGorsel { get; set; }

		public ICollection<SatisHareket> satisHarekets { get; set; }

		public int DepartmanId { get; set; }
		public virtual Departman departman { get; set; }


	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class Cariler
	{
        [Key] 
        public int CariId { get; set; }

		[StringLength(30,ErrorMessage ="En Fazla 30 Karakter Verebilirsiniz...")]
		public string CariAd { get; set; }

		[StringLength(30)]
		[Required(ErrorMessage ="Bu Alanı Boş Geçemezsiniz...")]
		public string CariSoyad { get; set; }

		[StringLength(15)]
		public string CariSehir { get; set; }

		[StringLength(50)]
		public string CariMail { get; set; }
		public bool Durum { get; set; }

		[StringLength(20)]
		public string CariSifre { get; set; }


		public ICollection<SatisHareket> satisHarekets { get; set; }
	}
}
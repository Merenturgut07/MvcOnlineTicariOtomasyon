using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class FaturaKalem
	{
        [Key]
        public int FaturaKalemId { get; set; }

        [StringLength(100)]
        public string Aciklama { get; set; }
        public string Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public string Tutar { get; set; }

		public int FaturaId { get; set; }
		public virtual Faturalar faturalar  { get; set; }
	}
}
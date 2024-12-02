using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class Detay
	{
        public int DetayId { get; set; }

        [StringLength(30)]
        public string UrunAd { get; set; }

		[StringLength(2000)]
		public string UrunBilgi { get; set; }
    }
}
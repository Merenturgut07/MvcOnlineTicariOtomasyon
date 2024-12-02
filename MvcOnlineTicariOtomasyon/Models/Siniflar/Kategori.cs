using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class Kategori
	{
        [Key]
        public int KategoriId { get; set; }

		[StringLength(30)]
		public string KategoriAdı  { get; set; }
        public ICollection<Urunler> urunlers { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class Mesajlar
	{
        [Key]
        public int MesajId { get; set; }

        [StringLength(50)]
        public string Gönderen  { get; set; }

		[StringLength(50)]
		public string Alıcı { get; set; }

		[StringLength(50)]
		public string Konu { get; set; }

		[StringLength(2000)]
		public string İçerik { get; set; }

		public DateTime Tarih { get; set; }
	}
}
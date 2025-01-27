﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class Departman
	{
		[Key]
        public int DepartmanId { get; set; }

		[StringLength(30)]
		public string DepartmanAd { get; set; }
		public bool Durum { get; set; }

		public ICollection<Personel> personels { get; set; }
    }
}
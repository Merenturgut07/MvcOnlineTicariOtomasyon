using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
	public class UrunDetayController : Controller
	{
		// GET: UrunDetay
		Context c = new Context();
		public ActionResult Index()
		{
			Class1 cs = new Class1();
			//var deger=c.urunlers.Where(x=>x.UrunId==1).ToList();
			cs.Deger1 = c.urunlers.Where(x => x.UrunId == 2).ToList();
			cs.Deger2 = c.detays.Where(y => y.DetayId == 2).ToList();
			return View(cs);
		}
	}
}
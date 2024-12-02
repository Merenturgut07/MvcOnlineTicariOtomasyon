using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
	public class CariController : Controller
	{
		// GET: Cari
		Context c = new Context();
		public ActionResult Index()
		{
			var degerler = c.carilers.Where(x => x.Durum == true).ToList();
			return View(degerler);
		}

		[HttpGet]
		public ActionResult YeniCari()
		{
			return View();
		}

		[HttpPost]
		public ActionResult YeniCari(Cariler p)
		{
			p.Durum = true;
			c.carilers.Add(p);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult CariSil(int id)
		{
			var cari = c.carilers.Find(id);
			cari.Durum = false;
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult CariGuncelle(int id)
		{
			var cari = c.carilers.Find(id);
			return View("CariGuncelle", cari);
		}



		[HttpPost]
		public ActionResult CariGuncelle(Cariler p)
		{
			if (!ModelState.IsValid)
			{
				return View("CariGuncelle");
			}
			var cari = c.carilers.Find(p.CariId);
			cari.CariAd = p.CariAd;
			cari.CariSoyad = p.CariSoyad;
			cari.CariSehir = p.CariSehir;
			cari.CariMail = p.CariMail;
			c.SaveChanges();
			return RedirectToAction("Index");

		}
		public ActionResult MusteriSatis(int id)
		{
			var degerler = c.satisHarekets.Where(x => x.CariId == id).ToList();
			var cr = c.carilers.Where(x => x.CariId == id).Select(y => y.CariAd + "" + y.CariSoyad).FirstOrDefault();
			ViewBag.cari = cr;
			return View(degerler);
		}


	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
	public class UrunController : Controller
	{
		// GET: Urun
		Context c = new Context();
		public ActionResult Index( string p)
		{
			var urun = from x in c.urunlers select x;
			if (! string.IsNullOrEmpty(p))
			{
				urun = urun.Where(y => y.UrunAd.Contains(p) || y.Marka.Contains(p) || y.kategori.KategoriAdı.Contains(p)); 
			}
			return View(urun.ToList());
		}

		[HttpGet]
		public ActionResult YeniUrun()
		{
			List<SelectListItem> deger1 = (from x in c.kategoris.ToList()
										   select new SelectListItem
										   {
											   Text = x.KategoriAdı,
											   Value = x.KategoriId.ToString()
										   }).ToList();
			ViewBag.dgr1 = deger1;
			return View();
		}
		[HttpPost]
		public ActionResult YeniUrun(Urunler u)
		{
			c.urunlers.Add(u);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult UrunSil(int id)
		{
			var urun = c.urunlers.Find(id);
			urun.Durum = false;
			c.SaveChanges();
			return RedirectToAction("Index");

		}


		[HttpGet]
		public ActionResult UrunGuncelle(int id)
		{
			List<SelectListItem> deger1 = (from x in c.kategoris.ToList()
										   select new SelectListItem
										   {
											   Text = x.KategoriAdı,
											   Value = x.KategoriId.ToString()
										   }).ToList();
			ViewBag.dgr1 = deger1;

			var urun = c.urunlers.Find(id);
			return View("UrunGuncelle", urun);
		}

		[HttpPost]
		public ActionResult UrunGuncelle(Urunler p)
		{
			var urun = c.urunlers.Find(p.UrunId);
			urun.AlisFiyati = p.AlisFiyati;
			urun.SatisFiyati = p.SatisFiyati;
			urun.Durum = p.Durum;
			urun.Stok = p.Stok;
			urun.KategoriId = p.KategoriId;
			urun.Marka = p.Marka;
			urun.UrunAd = p.UrunAd;
			urun.UrunGorsel=p.UrunGorsel;
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult UrunListesi()
		{
			var degerler = c.urunlers.ToList();
			return View(degerler);
		}

		[HttpGet]
		public ActionResult SatisYap(int id)
		{
			List<SelectListItem> deger1 = (from x in c.personels.ToList()
										   select new SelectListItem
										   {
											   Text = x.PersonelAd + " " + x.PersonelSoyad,
											   Value = x.PersonelId.ToString(),
										   }).ToList();

			ViewBag.dgr1 = deger1;
			var deger2 = c.urunlers.Find(id);
			ViewBag.dgr2 = deger2.UrunId;
			ViewBag.dgr3 = deger2.SatisFiyati;
			return View();
		}

		[HttpPost]
		public ActionResult SatisYap(SatisHareket p)
		{
			p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
			c.satisHarekets.Add(p);
			c.SaveChanges();
			return RedirectToAction("Index", "Satis");
		}
	}
}
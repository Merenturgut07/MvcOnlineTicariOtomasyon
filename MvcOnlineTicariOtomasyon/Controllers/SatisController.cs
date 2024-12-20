﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
	public class SatisController : Controller
	{
		// GET: Satis
		Context c = new Context();
		public ActionResult Index()
		{
			var values = c.satisHarekets.ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult YeniSatis()
		{
			List<SelectListItem> deger1 = (from x in c.urunlers.ToList()
										   select new SelectListItem
										   {
											   Text = x.UrunAd,
											   Value = x.UrunId.ToString(),
										   }).ToList();


			List<SelectListItem> deger2 = (from x in c.carilers.ToList()
										   select new SelectListItem
										   {
											   Text = x.CariAd + " " + x.CariSoyad,
											   Value = x.CariId.ToString(),
										   }).ToList();

			List<SelectListItem> deger3 = (from x in c.personels.ToList()
										   select new SelectListItem
										   {
											   Text = x.PersonelAd + " " + x.PersonelSoyad,
											   Value = x.PersonelId.ToString(),
										   }).ToList();


			ViewBag.dgr1 = deger1;
			ViewBag.dgr2 = deger2;
			ViewBag.dgr3 = deger3;

			return View();
		}

		[HttpPost]
		public ActionResult YeniSatis(SatisHareket s)
		{
			s.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
			c.satisHarekets.Add(s);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult SatisGetir(int id)
		{
			List<SelectListItem> deger1 = (from x in c.urunlers.ToList()
										   select new SelectListItem
										   {
											   Text = x.UrunAd,
											   Value = x.UrunId.ToString(),
										   }).ToList();


			List<SelectListItem> deger2 = (from x in c.carilers.ToList()
										   select new SelectListItem
										   {
											   Text = x.CariAd + " " + x.CariSoyad,
											   Value = x.CariId.ToString(),
										   }).ToList();

			List<SelectListItem> deger3 = (from x in c.personels.ToList()
										   select new SelectListItem
										   {
											   Text = x.PersonelAd + " " + x.PersonelSoyad,
											   Value = x.PersonelId.ToString(),
										   }).ToList();


			ViewBag.dgr1 = deger1;
			ViewBag.dgr2 = deger2;
			ViewBag.dgr3 = deger3;
			var deger = c.satisHarekets.Find(id);
			return View("SatisGetir",deger);
		}

		public ActionResult SatisGuncelle(SatisHareket p)
		{
			var sts=c.satisHarekets.Find(p.SatisHareketId);
			sts.CariId= p.CariId;
			sts.Adet = p.Adet;
			sts.Fiyat= p.Fiyat;
			sts.PersonelId=p.PersonelId;
			sts.Tarih= p.Tarih;
			sts.ToplamTutar=p.ToplamTutar;
			sts.UrunId= p.UrunId;
			c.SaveChanges();
			return RedirectToAction("Index");
		}


		public ActionResult SatisDetay(int id)
		{
			var degerler=c.satisHarekets.Where(x=>x.SatisHareketId==id).ToList();
			return View(degerler);
		}


	}
}
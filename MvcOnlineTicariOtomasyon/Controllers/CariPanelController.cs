using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MvcOnlineTicariOtomasyon.Controllers
{
	public class CariPanelController : Controller
	{
		// GET: CariPanel
		Context c = new Context();
		[Authorize]
		public ActionResult Index()
		{
			var mail = (string)Session["CariMail"];
			var degerler = c.Mesajlars.Where(x => x.Gönderen == mail).ToList();
			ViewBag.m = mail;

			//İd Değeri
			var mailid=c.carilers.Where(x=>x.CariMail==mail).Select(y=>y.CariId).FirstOrDefault();
			ViewBag.mid=mailid;

			//Toplam Satış
			var toplamsatis=c.satisHarekets.Where(x=>x.CariId==mailid).Count();
			ViewBag.toplamsatis=toplamsatis;

			//Toplam Tutar
			var toplamtutar = c.satisHarekets.Where(x => x.CariId == mailid).Sum(y=>y.ToplamTutar);
			ViewBag.toplamtutar = toplamtutar;

			//Toplam Ürün
			var toplamurun = c.satisHarekets.Where(x => x.CariId == mailid).Sum(y => y.Adet);
			ViewBag.toplamurun = toplamurun;

			//Ad Soyad
			var adsoyad=c.carilers.Where(x=>x.CariMail==mail).Select(y=>y.CariAd + " " + y.CariSoyad).FirstOrDefault();
			ViewBag.adsoyad=adsoyad;


			return View(degerler);
		}

		public ActionResult Siparislerim()
		{
			var mail = (string)Session["CariMail"];
			var id = c.carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
			var degerler = c.satisHarekets.Where(x => x.CariId == id).ToList();
			return View(degerler);
		}

		public ActionResult GelenMesajlar()
		{
			var mail = (string)Session["CariMail"];
			var mesajlar = c.Mesajlars.Where(x => x.Alıcı == mail).OrderByDescending(x => x.MesajId).ToList();
			return View(mesajlar);
		}

		public ActionResult GidenMesajlar()
		{
			var mail = (string)Session["CariMail"];
			var mesajlar = c.Mesajlars.Where(x => x.Gönderen == mail).OrderByDescending(x => x.MesajId).ToList();
			return View(mesajlar);
		}

		public PartialViewResult Partial1()
		{
			var mail = (string)Session["CariMail"];
			var gidensayisi = c.Mesajlars.Count(x => x.Gönderen == mail).ToString();
			ViewBag.d2 = gidensayisi;
			var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
			ViewBag.d1 = gelensayisi;
			return PartialView();
		}

		public ActionResult MesajDetay(int id)
		{
			var degerler = c.Mesajlars.Where(x => x.MesajId == id).ToList();
			return View(degerler);
		}

		public ActionResult GidenMesajlarDetay(int id)
		{
			var degerler = c.Mesajlars.Where(x => x.MesajId == id).ToList();
			return View(degerler);
		}

		[HttpGet]
		public ActionResult YeniMesaj()
		{
			return View();
		}

		[HttpPost]
		public ActionResult YeniMesaj(Mesajlar m)
		{
			var mail = (string)Session["CariMail"];
			m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
			m.Gönderen = mail;
			c.Mesajlars.Add(m);
			c.SaveChanges();
			return View();
		}

		public ActionResult KargoTakip(string p)
		{
			var k = from x in c.kargoDetays select x;
			k = k.Where(y => y.TakipKodu.Contains(p));
			return View(k.ToList());
		}

		public ActionResult CariKargoDetay(string id)
		{
			var degereler = c.kargoTakips.Where(x => x.TakipKodu == id).ToList();
			return View(degereler);
		}

		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("Index", "Login");
		}

		public PartialViewResult SifreGuncelle()
		{
			var mail = (string)Session["CariMail"];
			var id=c.carilers.Where(x=>x.CariMail==mail).Select(y=>y.CariId).FirstOrDefault();
			var caribul = c.carilers.Find(id);
			return PartialView("SifreGuncelle",caribul);
		}

		public ActionResult CariBilgiGuncelle(Cariler cr)
		{
			var cari = c.carilers.Find(cr.CariId);
			cari.CariAd = cr.CariAd;
			cari.CariSoyad = cr.CariSoyad;
			cari.CariSifre = cr.CariSifre;
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public PartialViewResult DuyuruPartial()
		{
			var veriler = c.Mesajlars.Where(x => x.Gönderen == "admin").ToList();
			return PartialView(veriler);
		}


	}
}
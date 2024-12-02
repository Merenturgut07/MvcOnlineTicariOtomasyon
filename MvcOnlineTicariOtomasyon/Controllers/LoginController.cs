using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		// GET: Login
		Context c = new Context();
		public ActionResult Index()
		{
			return View();
		}


		[HttpGet]
		public PartialViewResult PartialKayıtOl()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult PartialKayıtOl(Cariler p)
		{
			c.carilers.Add(p);
			c.SaveChanges();
			return PartialView();
		}


		[HttpGet]
		public ActionResult CariGirisYap()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CariGirisYap(Cariler p)
		{
			var bilgiler = c.carilers.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);
			if (bilgiler != null)
			{
				FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
				Session["CariMail"] = bilgiler.CariMail.ToString();
				return RedirectToAction("Index", "CariPanel");
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}

		}

		//Personel Girişi Kısımı Sql kısmında admin tablosu
		[HttpGet]
		public ActionResult AdminGiris()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AdminGiris(Admin p)
		{
			var bilgiler = c.admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
			if (bilgiler != null)
			{
				FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
				Session["KullanicıAd"] = bilgiler.KullaniciAd.ToString();
				return RedirectToAction("Index", "Kategori");
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}

		}
	}
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
	public class PersonelController : Controller
	{
		// GET: Personel
		Context c = new Context();
		public ActionResult Index()
		{
			var degerler = c.personels.ToList();
			return View(degerler);
		}

		[HttpGet]
		public ActionResult PersonelEkle()
		{
			List<SelectListItem> deger1 = (from x in c.departmens.ToList()
										   select new SelectListItem
										   {
											   Text = x.DepartmanAd,
											   Value = x.DepartmanId.ToString()
										   }).ToList();
			ViewBag.dgr1 = deger1;
			return View();
		}

		[HttpPost]
		public ActionResult PersonelEkle(Personel p)
		{
			if (Request.Files.Count > 0)
			{
				string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
				string uzanti = Path.GetExtension(Request.Files[0].FileName);
				string yol = "~/Image/" + dosyaadi + uzanti;
				Request.Files[0].SaveAs(Server.MapPath(yol));
				p.PersonelGorsel="/Image/"+dosyaadi+ uzanti;
			}
			c.personels.Add(p);
			c.SaveChanges();
			return RedirectToAction("Index");
		}


		[HttpGet]
		public ActionResult PersonelGuncelle(int id)
		{
			List<SelectListItem> deger1 = (from x in c.departmens.ToList()
										   select new SelectListItem
										   {
											   Text = x.DepartmanAd,
											   Value = x.DepartmanId.ToString()
										   }).ToList();
			ViewBag.dgr1 = deger1;
			var prs = c.personels.Find(id);
			return View("PersonelGuncelle", prs);
		}

		[HttpPost]
		public ActionResult PersonelGuncelle(Personel p)
		{
			if (Request.Files.Count > 0)
			{
				string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
				string uzanti = Path.GetExtension(Request.Files[0].FileName);
				string yol = "~/Image/" + dosyaadi + uzanti;
				Request.Files[0].SaveAs(Server.MapPath(yol));
				p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
			}
			var prsn = c.personels.Find(p.PersonelId);
			prsn.PersonelAd = p.PersonelAd;
			prsn.PersonelSoyad = p.PersonelSoyad;
			prsn.PersonelGorsel = p.PersonelGorsel;
			prsn.DepartmanId = p.DepartmanId;
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult PersonelListe()
		{
			var sorgu = c.personels.ToList();
			return View(sorgu);
		}


	}
}
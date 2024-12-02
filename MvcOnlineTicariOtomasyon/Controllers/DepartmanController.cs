using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
	[Authorize]
	public class DepartmanController : Controller
	{
		// GET: Departman
		Context c = new Context();
		public ActionResult Index()
		{
			var degerler = c.departmens.Where(x => x.Durum == true).ToList();
			return View(degerler);
		}

		[Authorize(Roles = "A")]
		[HttpGet]
		public ActionResult DepartmanEkle()
		{
			return View();
		}

		
		[HttpPost]
		public ActionResult DepartmanEkle(Departman d)
		{
			c.departmens.Add(d);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DepartmanSil(int id)
		{
			var dep = c.departmens.Find(id);
			dep.Durum= false;
			c.SaveChanges();
			return RedirectToAction("Index");
		}



		[HttpGet]
		public ActionResult DepartmanGuncelle(int id)
		{
			var dpt = c.departmens.Find(id);
			return View("DepartmanGuncelle", dpt);
		}


		[HttpPost]
		public ActionResult DepartmanGuncelle(Departman p)
		{
			var dpte = c.departmens.Find(p.DepartmanId);
			dpte.DepartmanAd=p.DepartmanAd;
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DepartmanDetay(int id)
		{
			var degereler=c.personels.Where(x=>x.DepartmanId==id).ToList();
			var dpt=c.departmens.Where(x=>x.DepartmanId==id).Select(y=>y.DepartmanAd).FirstOrDefault();
			ViewBag.d = dpt;
			return View(degereler);
		}

		public ActionResult DepartmanPersonelSatis(int id)
		{
			var degerler=c.satisHarekets.Where(x=>x.PersonelId==id).ToList();
			var per=c.personels.Where(x=>x.PersonelId==id).Select(y=>y.PersonelAd+" "+y.PersonelSoyad).FirstOrDefault();
			ViewBag.dp = per;
			return View(degerler);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
	public class KategoriController : Controller
	{
		// GET: Kategori
		Context c = new Context();
		public ActionResult Index(int sayfa=1)
		{
			var degerler =c.kategoris.ToList().ToPagedList(sayfa,4);
			return View(degerler);
		}


		[HttpGet]
		public ActionResult YeniKategori()
		{
			return View();
		}

		[HttpPost]
		public ActionResult YeniKategori(Kategori k)
		{
			c.kategoris.Add(k);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult KategoriSil(int id)
		{
			var kategori = c.kategoris.Find(id);
			c.kategoris.Remove(kategori);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult KategoriGuncelle(int id)
		{
			var kategori = c.kategoris.Find(id);
			return View("KategoriGuncelle", kategori);
		}

		[HttpPost]
		public ActionResult KategoriGuncelle(Kategori k)
		{
			var kategori = c.kategoris.Find(k.KategoriId);
			kategori.KategoriAdı=k.KategoriAdı;
			c.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult Deneme()
		{
			Class3 cs= new Class3();
			cs.Kategoriler = new SelectList(c.kategoris, "KategoriId", "KategoriAdı");
			cs.Urunler = new SelectList(c.urunlers, "UrunId", "UrunAd");
			return View(cs);
		}

		public JsonResult UrunGetir(int p )
		{
			var urunlistesi = (from x in c.urunlers
							   join y in c.kategoris
							   on x.kategori.KategoriId equals y.KategoriId
							   where x.kategori.KategoriId == p
							   select new
							   {
								   Text=x.UrunAd,
								   Value=x.UrunId.ToString()
							   }).ToList();
			return Json(urunlistesi,JsonRequestBehavior.AllowGet);

		}

	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
	public class FaturaController : Controller
	{
		// GET: Fatura
		Context c = new Context();
		public ActionResult Index()
		{
			var values = c.faturalars.ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult YeniFatura()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YeniFatura(Faturalar p)
		{
			var degerler = c.faturalars.Add(p);
			c.SaveChanges();
			return RedirectToAction("Index");
		}


		public ActionResult FaturaGetir(int id)
		{
			var values = c.faturalars.Find(id);
			return View("FaturaGetir", values);
		}

		public ActionResult FaturaGuncelle(Faturalar f)
		{
			var fatura = c.faturalars.Find(f.FaturaId);
			fatura.FaturaSeriNo = f.FaturaSeriNo;
			fatura.FaturaSıraNO = f.FaturaSıraNO;
			fatura.Saat = f.Saat;
			fatura.Tarih = f.Tarih;
			fatura.TeslimAlan = f.TeslimAlan;
			fatura.TeslimEden = f.TeslimEden;
			fatura.VergiDairesi = f.VergiDairesi;
			c.SaveChanges();
			return RedirectToAction("Index");
		}






		public ActionResult FaturaDetay(int id)
		{
			var degereler = c.faturaKalems.Where(x => x.FaturaId == id).ToList();
			return View(degereler);
		}

		[HttpGet]
		public ActionResult YeniFaturaKalem()
		{ 
			return View();
		}
		[HttpPost]
		public ActionResult YeniFaturaKalem(FaturaKalem p)
		{
		    c.faturaKalems.Add(p);
			c.SaveChanges();
			return RedirectToAction("Index");
		}


		public ActionResult FaturaKalemGetir(int id)
		{
			var values = c.faturaKalems.Find(id);
			return View("FaturaKalemGetir", values);
		}

		public ActionResult FaturaKalemGuncelle(FaturaKalem p)
		{
			var faturakalem = c.faturaKalems.Find(p.FaturaKalemId);
			faturakalem.Aciklama = p.Aciklama;
			faturakalem.Miktar = p.Miktar;
			faturakalem.BirimFiyat = p.BirimFiyat;
			faturakalem.Tutar = p.Tutar;
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Dinamik()
		{
			Class4 cs=new Class4();
			cs.deger1= c.faturalars.ToList();
			cs.deger2=c.faturaKalems.ToList();
			return View(cs);
		}

		public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSıraNo,DateTime Tarih, string VergiDairesi, string Saat, string TeslimEden, string TeslimAlan ,string Toplam , FaturaKalem[] kalemler)
		{
			Faturalar f= new Faturalar();
			f.FaturaSeriNo= FaturaSeriNo;
			f.FaturaSıraNO = FaturaSıraNo;
			f.Tarih = Tarih;
			f.VergiDairesi = VergiDairesi;
			f.Saat = Saat;
			f.TeslimEden= TeslimEden;
			f.TeslimAlan = TeslimAlan;
			f.Toplam =decimal.Parse(Toplam);
			c.faturalars.Add(f);

			foreach(var x in kalemler)
			{
				FaturaKalem fk=new FaturaKalem();
				fk.Aciklama=x.Aciklama;
				fk.BirimFiyat=x.BirimFiyat;
				fk.FaturaId=x.FaturaKalemId;
				fk.Miktar=x.Miktar;
				fk.Tutar=x.Tutar;
				c.faturaKalems.Add(fk);
			}

			c.SaveChanges();
			return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);
		}



	}
}
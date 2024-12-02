using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
	public class İstatistikController : Controller
	{
		// GET: İstatistik
		Context c = new Context();
		public ActionResult Index()
		{
			// ilk 4 lü  toplam adetleri
			var deger1 = c.carilers.Count().ToString();
			ViewBag.d1 = deger1;
			var deger2 = c.urunlers.Count().ToString();
			ViewBag.d2 = deger2;
			var deger3 = c.personels.Count().ToString();
			ViewBag.d3 = deger3;
			var deger4 = c.kategoris.Count().ToString();
			ViewBag.d4 = deger4;

			// 2. 4 lü

			// toplam stok sayısı
			var deger5 = c.urunlers.Sum(x => x.Stok).ToString();
			ViewBag.d5 = deger5;

			//Ürünler içerisindeki marka sayısı(Distinct() tekrarsız olarak say)
			var deger6 = (from x in c.urunlers select x.Marka).Distinct().Count().ToString();
			ViewBag.d6 = deger6;

			// stok  sayısı 20 nin altında olan ürünler
			var deger7 = c.urunlers.Count(x => x.Stok <= 20).ToString();
			ViewBag.d7 = deger7;

			// en yüksek fiyatlı ürünün adını yazdır
			var deger8 = (from x in c.urunlers orderby x.SatisFiyati descending select x.UrunAd).FirstOrDefault();
			ViewBag.d8 = deger8;


			//3. 4 lü
			// en düşük fiyatlı ürünün adını yazdır
			var deger9 = (from x in c.urunlers orderby x.SatisFiyati ascending select x.UrunAd).FirstOrDefault();
			ViewBag.d9 = deger9;


			//Buzdolabı Sayısı
			var deger10 = c.urunlers.Count(x => x.UrunAd == "Buzdolabı").ToString();
			ViewBag.d10 = deger10;

			//Laptop Sayısı
			var deger11 = c.urunlers.Count(x => x.UrunAd == "Laptop").ToString();
			ViewBag.d11 = deger11;

			//Ürün Tablosu İçerisinde İsmi En Çok Geçen Marka
			var deger12 = c.urunlers.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
			ViewBag.d12 = deger12;

			//Kasadaki toplam tutar
			var deger13 = c.urunlers.Where(u => u.UrunId == (c.satisHarekets.GroupBy(x => x.UrunId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
			ViewBag.d13 = deger13;


			//En Çok Satan Ürün
			var deger14 = c.satisHarekets.Sum(x => x.ToplamTutar).ToString();
			ViewBag.d14 = deger14;



			//Bugünkü Satışların Sayısı
			DateTime bugun = DateTime.Today;
			var deger15 = c.satisHarekets.Count(x => x.Tarih == bugun).ToString();
			ViewBag.d15 = deger15;

			//Bugünkü Kasa
			var deger16 = c.satisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?) y.ToplamTutar).ToString();
			ViewBag.d16 = deger16;



			return View();
		}

		public ActionResult KolayTablolar()
		{
			var sorgu = from x in c.carilers
						 group x by x.CariSehir into g
						 select new SinifGurup
						 {
							 Sehir = g.Key,
							 Sayi = g.Count()
						 };
			return View(sorgu.ToList());
		}

		public PartialViewResult Partial1()
		{
			var sorgu2 = from x in c.personels
						 group x by x.departman.DepartmanAd into g
						 select new SinifGurup2
						 {
							 DepartmanId = g.Key,
							 sayi = g.Count()
						 };
			return PartialView(sorgu2.ToList());
		}

		public PartialViewResult Partial2()
		{
			var sorgu = c.carilers.ToList();
			return PartialView(sorgu);
		}

		public PartialViewResult Partial3()
		{
			var sorgu = c.urunlers.ToList();
			return PartialView(sorgu);
		}


		public PartialViewResult Partial4()
		{
			var sorgu = from x in c.urunlers
						 group x by x.Marka into g
						 select new SınıfGurup3
						 {
							 Marka = g.Key,
							 Sayi = g.Count()
						 };
			return PartialView(sorgu.ToList());
		}


	}

}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
	public class Context : DbContext
	{
		public DbSet<Admin> admins { get; set; }
		public DbSet<Cariler> carilers { get; set; }
		public DbSet<Departman> departmens  { get; set; }
		public DbSet<FaturaKalem>faturaKalems  { get; set; }
		public DbSet<Faturalar> faturalars { get; set; }
		public DbSet<Gider> giders { get; set; }
		public DbSet<Kategori>kategoris  { get; set; }
		public DbSet<Personel>personels  { get; set; }
		public DbSet<SatisHareket>satisHarekets  { get; set; }
		public DbSet<Urunler>urunlers  { get; set; }
		public DbSet<Detay>detays  { get; set; }
		public DbSet<Yapilacak>yapilacaks  { get; set; }
		public DbSet<KargoDetay>kargoDetays  { get; set; }
		public DbSet<KargoTakip>kargoTakips  { get; set; }
		public DbSet<Mesajlar>Mesajlars  { get; set; }

	}
}
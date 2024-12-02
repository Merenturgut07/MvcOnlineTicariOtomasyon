namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_mesajlasma : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mesajlars",
                c => new
                    {
                        MesajId = c.Int(nullable: false, identity: true),
                        Gönderen = c.String(maxLength: 50),
                        Alıcı = c.String(maxLength: 50),
                        Konu = c.String(maxLength: 50),
                        İçerik = c.String(maxLength: 2000),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MesajId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mesajlars");
        }
    }
}

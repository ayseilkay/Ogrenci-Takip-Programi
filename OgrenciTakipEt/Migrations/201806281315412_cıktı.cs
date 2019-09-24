namespace OgrenciTakipEt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cıktı : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bolumlers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Bolum = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        code = c.String(nullable: false, maxLength: 2),
                        name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.code);
            
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 100),
                        Soyad = c.String(nullable: false, maxLength: 100),
                        Bolum = c.String(maxLength: 250),
                        Posta = c.String(nullable: false, maxLength: 100),
                        Tel = c.String(nullable: false, maxLength: 100),
                        isyeri = c.String(nullable: false, maxLength: 100),
                        Adres = c.String(maxLength: 500),
                        Sehir = c.String(maxLength: 100),
                        Resim = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ogrencis");
            DropTable("dbo.Cities");
            DropTable("dbo.Bolumlers");
        }
    }
}

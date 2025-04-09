namespace PlayMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Cancion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cancion",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Titulo = c.String(),
                    fkArtista = c.Int(nullable: false),
                    Album = c.String(),
                    Genero = c.String(),
                    Duracion = c.Int(nullable: false),
                    Url = c.String(),
                })
                .PrimaryKey(t => t.Id);
            CreateIndex("dbo.Cancion", "fkArtista");
            AddForeignKey("dbo.Cancion", "fkArtista", "dbo.Artista", "Id", cascadeDelete: true);
        }
        public override void Down()
        {
            DropForeignKey("dbo.Cancion", "fkArtista", "dbo.Artista");
            DropIndex("dbo.Cancion", new[] { "fkArtista" });
            DropTable("dbo.Cancion");
        }

    }
}
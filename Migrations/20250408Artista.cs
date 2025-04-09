namespace PlayMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Artista : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artista",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Cancion", "fkArtista", c => c.Int(nullable: false));
            CreateIndex("dbo.Cancion", "fkArtista");
            AddForeignKey("dbo.Cancion", "fkArtista", "dbo.Artista", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Cancion", "fkArtista", "dbo.Artista");
            DropIndex("dbo.Cancion", new[] { "fkArtista" });
            DropColumn("dbo.Cancion", "fkArtista");
            DropTable("dbo.Artista");
        }
    }
}
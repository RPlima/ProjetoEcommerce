namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        NomeCateg = c.String(nullable: false),
                        DescCategoria = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            AddColumn("dbo.Produtos", "Categoria_CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtos", "Categoria_CategoriaId");
            AddForeignKey("dbo.Produtos", "Categoria_CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
            DropColumn("dbo.Produtos", "Categoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtos", "Categoria", c => c.String(nullable: false));
            DropForeignKey("dbo.Produtos", "Categoria_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "Categoria_CategoriaId" });
            DropColumn("dbo.Produtos", "Categoria_CategoriaId");
            DropTable("dbo.Categorias");
        }
    }
}

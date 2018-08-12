namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixBanco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtos", "Categoria_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "Categoria_CategoriaId" });
            AlterColumn("dbo.Produtos", "Categoria_CategoriaId", c => c.Int());
            CreateIndex("dbo.Produtos", "Categoria_CategoriaId");
            AddForeignKey("dbo.Produtos", "Categoria_CategoriaId", "dbo.Categorias", "CategoriaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "Categoria_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "Categoria_CategoriaId" });
            AlterColumn("dbo.Produtos", "Categoria_CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtos", "Categoria_CategoriaId");
            AddForeignKey("dbo.Produtos", "Categoria_CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
        }
    }
}

namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableProduto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtos", "Nome", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Produtos", "Descricao", c => c.String(maxLength: 100));
            AlterColumn("dbo.Produtos", "Categoria", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtos", "Categoria", c => c.String());
            AlterColumn("dbo.Produtos", "Descricao", c => c.String());
            AlterColumn("dbo.Produtos", "Nome", c => c.String());
        }
    }
}

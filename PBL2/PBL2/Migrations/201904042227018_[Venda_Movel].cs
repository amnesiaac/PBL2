namespace PBL2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Venda_Movel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movels", "Venda_Pk_Venda", c => c.Int());
            CreateIndex("dbo.Movels", "Venda_Pk_Venda");
            AddForeignKey("dbo.Movels", "Venda_Pk_Venda", "dbo.Vendas", "Pk_Venda");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movels", "Venda_Pk_Venda", "dbo.Vendas");
            DropIndex("dbo.Movels", new[] { "Venda_Pk_Venda" });
            DropColumn("dbo.Movels", "Venda_Pk_Venda");
        }
    }
}

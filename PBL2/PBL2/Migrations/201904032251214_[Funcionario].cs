namespace PBL2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Funcionario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcionarios", "Venda_Pk_Venda", c => c.Int());
            CreateIndex("dbo.Funcionarios", "Venda_Pk_Venda");
            AddForeignKey("dbo.Funcionarios", "Venda_Pk_Venda", "dbo.Vendas", "Pk_Venda");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionarios", "Venda_Pk_Venda", "dbo.Vendas");
            DropIndex("dbo.Funcionarios", new[] { "Venda_Pk_Venda" });
            DropColumn("dbo.Funcionarios", "Venda_Pk_Venda");
        }
    }
}

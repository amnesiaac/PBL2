namespace PBL2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        Pk_Funcionario = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Funcionario);
            
            CreateTable(
                "dbo.Movels",
                c => new
                    {
                        Pk_Movel = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cor = c.String(),
                        Medidas = c.String(),
                        Material = c.String(),
                        Link = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Movel);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        Pk_Venda = c.Int(nullable: false, identity: true),
                        Fk_Funcionario = c.Int(nullable: false),
                        Fk_Movel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pk_Venda)
                .ForeignKey("dbo.Funcionarios", t => t.Fk_Funcionario, cascadeDelete: true)
                .ForeignKey("dbo.Movels", t => t.Fk_Movel, cascadeDelete: true)
                .Index(t => t.Fk_Funcionario)
                .Index(t => t.Fk_Movel);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "Fk_Movel", "dbo.Movels");
            DropForeignKey("dbo.Vendas", "Fk_Funcionario", "dbo.Funcionarios");
            DropIndex("dbo.Vendas", new[] { "Fk_Movel" });
            DropIndex("dbo.Vendas", new[] { "Fk_Funcionario" });
            DropTable("dbo.Vendas");
            DropTable("dbo.Movels");
            DropTable("dbo.Funcionarios");
        }
    }
}

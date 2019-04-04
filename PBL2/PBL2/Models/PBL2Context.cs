using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PBL2.Models
{
    public class PBL2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PBL2Context() : base("name=PBL2Context")
        {
        }

        public System.Data.Entity.DbSet<PBL2.Models.Funcionario> Funcionarios { get; set; }

        public System.Data.Entity.DbSet<PBL2.Models.Movel> Movels { get; set; }

        public System.Data.Entity.DbSet<PBL2.Models.Venda> Vendas { get; set; }
    }
}

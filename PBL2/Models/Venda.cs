using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PBL2.Models
{
    public class Venda
    {
        [Key]
        public int Pk_Venda { get; set; }
        [ForeignKey("Funcionario")]
        public int Fk_Funcionario { get; set; }
        public Funcionario Funcionario { get; set; }
        [ForeignKey("Movel")]
        public int Fk_Movel { get; set; }
        public Movel Movel { get; set; }

        public void setstatusfuncionario()
        {
            Funcionario.Status = "Indisponivel";
        }
        public void setstatusmovel()
        {
            Movel.Status = "Em construção";

        }

    }
}
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
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        public virtual ICollection<Movel> Moveis{ get; set; }

    public bool mudastatusFuncionario()
    {
        if (Funcionario.Status== "Disponivel")
        {
            return true;
        }
        return false;
    }
        public bool mudastatusMovel()
        {
            if (Movel.Status == "solicitado")
            {
                return true;
            }
            return false;
        }
    }
}
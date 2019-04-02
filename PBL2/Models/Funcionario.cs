using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PBL2.Models
{
    public class Funcionario
    {
        [Key]
        public int Pk_Funcionario { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }

        public Funcionario ()
            {
            Status = "Disponivel";
            }
           
}
    }

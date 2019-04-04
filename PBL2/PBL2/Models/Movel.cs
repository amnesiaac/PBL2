using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PBL2.Models
{
    public class Movel
    {
       
        [Key]
        public int Pk_Movel { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string Medidas { get; set; }
        public string Material { get; set; }
        public string Link { get; set; }
        public string Status { get; set; }
        public Movel(){
        Status = "solicitado";           
 }
}
}
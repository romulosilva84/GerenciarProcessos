using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciarProcessos.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciarProcessos.Models
{
    public class Processo
    {
        public int ProcessoID { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Valor")]
        public int Valor { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        public bool Estaativo { get; set; }

        public ICollection<Associacao> Associacoes { get; set; }
    }
}

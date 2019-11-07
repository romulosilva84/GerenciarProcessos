using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciarProcessos.Models
{
    public class Associacao
    {
        [Key]
        public int ClienteID { get; set; }
        public int ProcessoID { get; set; }
        public Cliente Cliente { get; set; }
        public Processo Processo { get; set; }
    }
}

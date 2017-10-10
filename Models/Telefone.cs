using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalaoIedaV4.Models
{
    public class Telefone
    {
        [Key]
        public int idTelefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Telefone Principal*")]
        [DataType(DataType.PhoneNumber)]
        public int num_tel_principal { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Telefone Secundário*")]
        [DataType(DataType.PhoneNumber)]
        public int num_tel_secundario { get; set; }

        [ScaffoldColumn(false)]
        public DateTime data_atualizacao_principal { get; set; }

        [ScaffoldColumn(false)]
        public DateTime data_atualizacao_secundario { get; set; }
    }
}

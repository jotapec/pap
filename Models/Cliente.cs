using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalaoIedaV4.Models
{
    public class Cliente
    {

        [Key]
        public int idCliente { get; set; }


        [ScaffoldColumn(false)]
        public virtual Telefone Telefone { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Nome*")]
        [DataType(DataType.Text)]
        public string desc_nome_cliente { get; set; }


        [ScaffoldColumn(false)]
        public DateTime data_cadastro { get; set; }

        [ScaffoldColumn(false)]
        public DateTime data_atualizacao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime data_prox_servico { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Email*")]
        [DataType(DataType.EmailAddress)]
        public string desc_email_cliente { get; set; }


    }
}
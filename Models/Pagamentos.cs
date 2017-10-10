using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalaoIedaV4.Models
{
    public class Pagamentos
    {

        [Key]
        public int idPagamentos { get; set; }


        [ScaffoldColumn(false)]
        public virtual Tipos_Pagamento Tipos_Pagamento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Data do Pagamento*")]
        [DataType(DataType.Date)]
        public DateTime dt_pagamento { get; set; }

        [Display(Name = "Valor Pago*")]
        [DataType(DataType.Text)]
        public double vl_pago { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Valor Cobrado*")]
        [DataType(DataType.Text)]
        public double vl_cobrado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Status do pagamento")]
        [DataType(DataType.Text)]
        public string status_pagamento { get; set; }

    }
}

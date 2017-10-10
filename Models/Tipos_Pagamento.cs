using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalaoIedaV4.Models
{
    public class Tipos_Pagamento
    {
        [Key]
        public int idTipos_pagamento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Tipo do pagamento")]
        [DataType(DataType.Text)]
        public string desc_tipo_pagamento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Natureza do pagamento")]
        [DataType(DataType.Text)]
        public string desc_natureza_pagamento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Canal do Pagamento")]
        [DataType(DataType.Text)]
        public string desc_canal_pagamento { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Data de início de vigência*")]
        [DataType(DataType.Date)]
        public DateTime dt_ini_vigencia { get; set; }


        [Display(Name = "Data de fim de vigência*")]
        [DataType(DataType.Date)]
        public DateTime dt_fim_vigencia { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalaoIedaV4.Models
{
    public class Tipo_Servico
    {
        [Key]
        public int idTipos_Servico { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Descrição do tipo do serviço")]
        [DataType(DataType.Text)]
        public string desc_tipo_servico { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Data de início de vigência*")]
        [DataType(DataType.Date)]
        public DateTime dt_ini_vigencia_serv { get; set; }


        [Display(Name = "Data de fim de vigência*")]
        [DataType(DataType.Date)]
        public DateTime dt_fim_vigencia_serv { get; set; }




    }
}
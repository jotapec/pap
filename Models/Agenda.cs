using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalaoIedaV4.Models
{
    public class Agenda
    {
        [Key]
        public int idAgenda { get; set; }


        [ScaffoldColumn(false)]
        public virtual Tipo_Servico Tipo_Servico { get; set; }


        [ScaffoldColumn(false)]
        public virtual Cliente Cliente { get; set; }

 



        [ScaffoldColumn(false)]
        public DateTime dt_agendamento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Data Agendada")]
        [DataType(DataType.DateTime)]
        public DateTime dt_data_agendada { get; set; }


        [Display(Name = "Descrição do Serviço")]
        [DataType(DataType.Text)]
        public string desc_servico { get; set; }


        [Display(Name = "Tempo estimado para a execução")]
        [DataType(DataType.Text)]                                                //TimeSpan ts = TimeSpan.FromSeconds(90);                   USO FUTURO
        public int tempo_estimado { get; set; }                                  // txtDate = string.Format("Full time: {0}", new DateTime(ts.Ticks).ToString("HH:mm:ss"));

        [Display(Name = "Cancelamento?")]
        public bool cancelamento { get; set; }

        
        [ScaffoldColumn(false)]
        public DateTime dt_cancelamento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime dt_atualizacao { get; set; }

    }
}
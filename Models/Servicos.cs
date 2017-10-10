using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalaoIedaV4.Models
{
    public class Servico
    {
        [Key]
        public int idServico { get; set; }

        [ScaffoldColumn(false)]
        public virtual Pagamentos Pagamentos { get; set; } //Chave estrangeira


        [ScaffoldColumn(false)]
        public virtual Cliente Cliente { get; set; } //Chave estrangeira


        [ScaffoldColumn(false)]
        public virtual Tipo_Servico Tipo_Servico { get; set; }

        [ScaffoldColumn(false)]
        public virtual Agenda Agenda { get; set; }

        [ScaffoldColumn(false)]
        public DateTime data_servico { get; set; } // informação virá de agenda -> data agendada

        [Display(Name = "Descrição do serviço*")]
        [DataType(DataType.Text)]
        public string desc_comentario_servico { get; set; }


        [Display(Name = "Foto do serviço*")]
        [DataType(DataType.ImageUrl)]
        public string img_foto_servico { get; set; }  //confirmar se é assim salvar foto.






    }
}
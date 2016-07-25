using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace AgenciaEF_BO.Models
{
    [Table("RECIBOS")]
    public class Recibos
    {
        [Key]
        public int RECIBO_ID { set; get; }

        [Required]
        public int TIPO_REC_ID { set; get; }

        public virtual Tipos Tipos { set; get; }

        [Required]
        public int NUM_REC { set; get; }

        [Required]
        public DateTime FECHA { set; get; }

        [Required]
        public int  CTE_ID  { set; get; }

        [Required]
        public decimal IMPORTE_ITEBIS { set; get; }

        [Required]
        public decimal  IMPORTE_TOTAL  { set; get; }

        [Required]
        public decimal IMPORTE_CTA { set; get; }

        [Required]
        public bool REC_CREDITO { set; get; }
        
        [Required]
        public int ESTADO_ID { set; get; }


        [Required]
        public int SUC_ID { set; get; }
        
        [Required]
        public DateTime F_VCTO { set; get; }

        [Required]
        public DateTime F_COBRO { set; get; }
        
        [Required]
        public int TIP_FISCAL { set; get; }

       
        [MaxLength(19)]
        public string NUM_FISCAL { set; get; }


        [Required]
        public int RECIBO_ID_ANUL { set; get; }

        
        [Required]
        public int COUNTER_ID { set; get; }

        [Required]
        public DateTime FECHA_CREA { set; get; }     

        [Required]
        public DateTime FECHA_MODIF { set; get; }

        [Required]
        public string USER_CREA { set; get; }

        [Required]
        public string USER_MODIFICA { set; get; }

        public decimal ITBIS { set; get; }

        public decimal IMPORTE_GRAVADO { set; get; }

        public virtual  ICollection<RecibosDet> RecibosDet { set; get; }

        public virtual Sucursales Sucursales { set; get; }

        public virtual Clientes Clientes { set; get; }

        public virtual Estados Estados { set; get; }

        public bool IMPRESO { set; get; }


     

        
        
    }
}

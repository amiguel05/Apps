using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models.VW
{
    [Table("VW_CUADRE_CAJA")]
    public class vw_cuadre_caja
    {
        [Key]
        public int MOVCAJA_ID { set; get; }
        public int TIP_MOV { set; get; }
        public string TIPO_DESCR { set; get; }
        public int COUNTER_ID { set; get; }
        public string CAJERO { set; get; }
        public int SUC_ID { set; get; }
        public decimal IMPORTE { set; get; }
        public int RECIBO_ID { set;  get; }
        public string NUM_FISCAL { set; get; }
        public string RECIBO { set; get; }
        public string TIPO_REC_DESC { set; get; }
        public int CTE_ID { set; get; }
        public string CTE_NUMERO_EPS { set; get; }
        public bool REC_CREDITO { set; get; }
        public DateTime FECHA { set; get; }
    }
}

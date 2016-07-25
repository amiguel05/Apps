using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models.VW
{
    [Table("VW_BULTOS_VALORES")]
    public class vw_bultos_valores
    {

        [Key]
        public int BLT_NUMERO { set; get; }

        //BLT_ESTADO_ID
        [Required]
        public int BLT_ESTADO_ID { set; get; }


        [Required]
        public int CTE_ID { set; get; }

        [Required]
        public int SUC_ID { set; get; }

        [Required]
        public string BLT_CODIGO_BARRA { set; get; }

        [Required]
        public string BLT_TRACKING_NUMBER { set; get; }

        //BLT_PESO
        public decimal BLT_PESO { set; get; }

        //CONTENIDO
        public string CONTENIDO { set; get; }
        //   C.CTE_NUMERO_EPS, C.CTE_APELLIDO, C.CTE_NOMBRE, C.CTE_CREDITO, C.CTE_LIMITE_CREDITO, C.CTE_BALANCE_DISPONIBLE,

        public string CTE_NUMERO_EPS { set; get; }

        public string CTE_APELLIDO { set; get; }

        public string CTE_NOMBRE { set; get; }

        public bool CTE_CREDITO { set; get; }

        public decimal CTE_LIMITE_CREDITO { set; get; }

        public decimal CTE_BALANCE_DISPONIBLE { set; get; }

        //MONTO
        public decimal MONTO { set; get; }


    }
}

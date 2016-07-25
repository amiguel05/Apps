using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("BULTOS")]
    public class Bultos
    {
        [Key]
        public int BLT_NUMERO { set; get; }


        [Required]
        public int CTE_ID { set; get; }

        [Required]
        public int SUC_ID { set; get; }

        [Required]
        public int PROD_ID { set; get; }

        [MaxLength(15)]
        public string MAN_GUIA { set; get; }

         [MaxLength(10)]
        public string MAN_MANIFIESTO { set; get; }

         [MaxLength(20)]
        public string BLT_GUIA_HIJA { set; get; }

        [Required]
        [MaxLength(20)]
        public string BLT_CODIGO_BARRA { set; get; }

         [MaxLength(10)]
        public string BLT_PONUMBER { set; get; }

         [MaxLength(40)]
        public string BLT_TRACKING_NUMBER { set; get; }

        [Required]
        public int ORI_ID { set; get; }

        [Required]
        public int DEST_ID { set; get; }

        [Required]
        public int BLT_PIEZAS { set; get; }

        [Required]
        public decimal BLT_PESO { set; get; }

        [Required]
        public decimal BLT_PESO_REAL { set; get; }

        [Required]
        public decimal BLT_VOLUMEN { set; get; }

        [Required]
        public int BLT_ESTADO_ID { set; get; }


          [MaxLength(11)]
        public string BLT_UBICACION { set; get; }

        [Required]
        public DateTime BLT_FECHA_RECEPCION { set; get; }


        public string BLT_BOLSA_SUPLIDOR { set; get; }


        public DateTime? BLT_FECHA_ENTREGADO { set; get; }

        [Required]
        public DateTime BLT_RECEP_SUPLIDOR { set; get; }

        [Required]
        public DateTime BLT_DESPA_SUPLIDOR { set; get; }

        [Required]
        public decimal BLT_PESO_SUPLIDOR { set; get; }

        [Required]
        public int BLT_VENTANILLA { set; get; }

        [Required]
        public int BLT_PIEZAS_SUPLIDOR { set; get; }

        [Required]
        [MaxLength(6)]
        public string BLT_MANIFIESTO_SUCURSAL { set; get; }
            
        [Required]
        [MaxLength(6)]
        public string BLT_BOLSA_SUCURSAL { set; get; }

        [MaxLength(10)]
        public string BLT_LIQUIDADOR { set; get; }

        public bool BLT_ENTREGAR { set; get; }

        [MaxLength(4)]
        public string BLT_HORA_RECIBIDO { set; get; }

        [MaxLength(4)]
        public string BLT_HORA_ENTREGADO { set; get; }

        [MaxLength(3)]
        public string UBI_CODIGO { set; get; }

        [Required]
        public int CON_CODIGO_ID { set; get; }

        [MaxLength(12)]
        public string BLT_WAREHOUSE { set; get; }

        public decimal BLT_MONTO_SELLOS { set; get; }

        public decimal BLT_PORCIENTO_SELLO { set; get; }

        [Required]
        public bool BLT_ADUANA { set; get; }

        [Required]
        public decimal BLT_VALOR_FOB { set; get; }


        public decimal BLT_ALTO { set; get; }


        public decimal BLT_LARGO { set; get; }


        public decimal BLT_ANCHO { set; get; }

        [Required]
        public  int ALM_CODIGO { set; get; }

        [MaxLength(255)]
        public string BLT_OBSERVACION { set; get; }

        [Required]
        public bool BLT_ABIERTO_ADUANA { set; get; }

        [MaxLength(200)]
        public string REMITENTE { set; get; }

        [MaxLength(200)]
        public string DESTINATARIO { set; get; }

        [MaxLength(200)]
        public string CONTENIDO { set; get; }

        [Required]
        public int USUARIO_ID { set; get; }

        [Required]
        public DateTime FECHA_MODIF { set; get; }

        public virtual Clientes Clientes { set; get; }

        public virtual Sucursales Sucursales { set; get; }

        public virtual Productos Productos { set; get; }

        public virtual ICollection<BultosValores> BultosValores { set; get; }

       
    }
}

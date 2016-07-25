using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("CLIENTES")]
    public class Clientes
    {
        [Key]
        public int CTE_ID { get; set; }

        [Required]
        public string CTE_NUMERO_EPS { get; set; }

       
        public string CTE_EPS_DESTINADO { get; set; }

        public string CTE_CEDULA { get; set; }

        public string CTE_RNC { get; set; }

        public string CTE_APELLIDO { get; set; }

        [Required]
        public string CTE_NOMBRE { get; set; }

        public string CTE_DIRECCION_CASA { get; set; }

        public string CTE_DIRECCION_OFICINA { get; set; }

        public DateTime CTE_FECHA_NACIMIENTO { get; set; }

        

        public string CTE_FAX { get; set; }
        public string CTE_TELEFONO_CASA { get; set; }
        public string CTE_TELEFONO_OFICINA {set;get;}


        [Required]
        public int TIPO_MENSAJERIA_ID { get; set; }

        [Required]
        public int CTE_TIPO_ID { get; set; }

         [Required]
        public int CTE_ESTADO_ID { get; set;  }

        public DateTime CTE_FECHA_INGRESO { get; set; }

        [Required]
        public int CTE_RESPRESENTANTE_ID { get; set; }

      

        public string CTE_REPRESENTANTE { get; set; }

        public string CTE_CARGO { get; set; }

        public string CTE_ENCARGADO_PAGOS { get; set; }

        public string CTE_SECRETARIA { get; set; }

        [Required]
        public bool CTE_CREDITO { get; set; }

        public DateTime CTE_FECHA_VENCIMIENTO { get; set; }

        public bool CTE_JUNK_MAIL { get; set; }

        public string CTE_CODIGO_VOICE { set; get; }

        public string CTE_MENSAJE_PIE { set; get; }
        
        public string CTE_RECIBO_RENOV { set; get; }

        public DateTime? CTE_FECHA_RENOVACION { set; get; }

        [Required]
        public bool CTE_EXONERADO_ADUANA { set; get; }

        [Required]
        public bool CTE_LLAMAR_VOICE { set; get; }

        public int CTE_SUC_ID { set; get; }

        public string  CTE_EMAIL { set; get; }

        public string CTE_EXT_TELOFIC { set; get; }

        [Required]
        public int COD_TARIFA { set; get; }

        [Required]
        public decimal CTE_LIMITE_CREDITO { set; get; }

        [Required]
        public decimal CTE_DIAS_CREDITOS { set; get; }

        [Required]
        public decimal CTE_CHEQUES_DEV { set; get; }

        [Required]
        public decimal CTE_MORA { set; get; }

        [Required]
        public decimal CTE_PORCENTAJE_SOBRE { set; get; }

        [Required]
        public bool CTE_PAGO_TARJETA { set; get; }

        [Required]
        public bool CTE_PAGO_CHEQUE { set; get; }

        [Required]
        public decimal CTE_CREDITO_DISPONIBLE { set; get;  }

        [Required]
        public decimal CTE_BALANCE_DISPONIBLE { set; get; }

        [Required]
        public bool CTE_ENVIAR_FAX { set; get; }

        [Required]
        public bool CTE_ENVIAR_EMAIL { set; get; }

        [Required]
        public int CTE_DIA_CORTE { set; get; }

        [Required]
        public int  CFG_METODO_TARIFA { set; get;  }

        public decimal CTE_LIBRAS_ACUMULADAS { set; get;  }

        public string CTE_COBRADOR {set; get;}

        public string CTE_DIREC_INTERNET { set; get;  }

        public string CTE_CELULAR { set; get; }

        [Required]
        public decimal CTE_LIBRAS_GRATIS { set; get; }

        [Required]
        public bool CTE_CORRESPONDENCIA { set; get; }

        public DateTime? CTE_FECHA_VOICE { set; get; }

        public string CTE_LLAVE { set; get; }

        [Required]
        public decimal CTE_LIBRAS_ASIGNADAS { set; get;  }

        
        public string CTE_NOMBRE_COMPANIA { set; get;  }


        public string CTE_PASAPORTE { set; get;  }

      

        [Required]
        public int COD_PAIS { set; get; }

        [Required]
        public bool CTE_BLOQUEO { set; get; }

        public DateTime? CTE_FECHA_CAMBIO { set; get;  }

        [Required]
        public bool CTE_ENVIAR_CELULAR { set; get;  }

        public DateTime? CTE_ENTRO_WEB { set; get; }

        public DateTime? CTE_FECHA_NOFICIACION { set; get; }

        public string CTE_MENSAJE_EMBARQUE { set; get; }

        [Required]
        public int CTE_TIPO_FISCAL { set; get; }

        [Required]
        public int CTE_MANEJO_OPERACIONAL { set; get; }



    }
}

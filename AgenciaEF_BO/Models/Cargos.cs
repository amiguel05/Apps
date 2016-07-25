using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgenciaEF_BO.Models
{
    [Table("CARGOS")]
   public  class Cargos
    {
        [Key]
        public int CARGO_ID { set; get; }

        [Required]
        public string CAR_CODIGO { set; get; }

        [Required]
        public string CAR_DESCRIPCION { set; get; }

        [Required]
        public string CAR_TIPO { set; get; }

        [Required]
        public bool CAR_ESTADO { set; get; }
        
         [Required]
        public string CAR_DIRECTO_TABLA { set; get; }
        //CAR_FACTURAR_APARTE

         [Required]
         public string CAR_FIJO_MULTIPLICAR { set; get; }

         [Required]
         public bool CAR_ITBIS { set; get; }
        //CAR_TOPE_MAXIMO
         [Required]
         public string CAR_TOPE_MAXIMO { set; get; }


        //CAR_MINIMO_FACTURAR
         [Required]
         public decimal CAR_MINIMO_FACTURAR { set; get; }

        //CAR_RED_ENTEROS
         [Required]
         public bool CAR_RED_ENTEROS { set; get; }

         [Required]
         public bool CAR_REDONDEAR { set; get; }

         [Required]
         public bool CAR_SUMAR { set; get; }

        //CAR_BASE_ID
         [Required]
         public int CAR_BASE_ID { set; get; }

        //ITBIS
         [Required]
         public decimal ITBIS { set; get; }

         [Required]
         public bool CAR_NCF { set; get; }

        [Required]
         public bool CAR_NC { set; get; }

        [Required]
        public bool CAR_COBROS { set; get; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgenciaEF_BO.Models
{

    [Table("BULTOS_ENVIOS")]
    public class BultosEnvios
    {
        [Key]
        public int BULTO_ENV_ID { set; get; }


        [Required]
        public int BLT_NUMERO { set; get; }

        [Required]
        public string REMITENTE { set; get; }


        public string REMITENTE_DIR1 { set; get; }

        public string REMITENTE_DIR2 { set; get; }


        public string REM_CIUDAD { set; get; }


        public string REM_PROVINCIA { set; get; }

        public string REM_ZIP { set; get; }


         [Required]
        public int REM_PAIS_ID { set; get; }

        public string REM_TELEFONO { set; get; }

        public string REM_EMAIL { set; get; }

         [Required]
         public string DESTINATARIO { set; get; }

         [Required]
         public string DEST_DIR1 { set; get; }
        
         [Required]
         public string DEST_DIR2 { set; get; }

        [Required]
         public string DEST_CIUDAD { set; get; }

        [Required]
         public string DEST_PROVINCIA { set; get; }

         public string DEST_ZIP { set; get; }

         [Required]
         public int DEST_PAIS_ID { set; get; }

        public string DEST_TEL { set; get; }

        public string DEST_EMAIL { set; get; }

   
    }
}

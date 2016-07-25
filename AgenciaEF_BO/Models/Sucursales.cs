using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("SUCURSALES")]
    public class Sucursales
    {
        
        [Key]
        public int SUC_ID { get; set; }
        [Required(ErrorMessage = "Debe ingresar el código de sucursal.")]
        public string SUC_CODIGO { get; set; }
        public string SUC_DESCRIPCION { get; set; }
        public string SUC_ESTADO { get; set; }
        public int COM_CODIGO { get; set; }
        public int ALM_CODIGO { get; set; }
        public string BLT_UBICACION{ get; set; }

        public virtual Empresas Empresas { get; set; }

    }
}

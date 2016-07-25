using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 *  [Required(ErrorMessage = "Position name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        [Display(Name = "Position name")]    
 */
namespace AgenciaEF_BO.Models
{
    [Table("COMPANIAS")]
    public class Empresas
    {
        [Key]
        public int COM_CODIGO { set; get; }

        [Required(ErrorMessage="La descripción no puede quedar en blanco")]
        [Display(Name="Descripción")]
        public string COM_DESCRIPCION { set; get; }

        [Required(ErrorMessage = "Debe registrar el RNC")]
        public string COM_RNC { set; get; }
        public decimal? COM_ANO_PROC { set; get; }
        public decimal? COM_MES_PROC { set; get; }

        public string COM_RESPONSABLE { set; get; }
        public string COM_DIRECCION { set; get; }
        public string COM_TELEFONO { set; get; }
        public string COM_FAX { set; get; }
        public string COM_EMAIL { set; get; }
        public string COM_ESTADO { set; get; }

        public DateTime? COM_FEC_CREA { set; get; }
        public string COMA_USR_CREA { set; get; }
        public string COM_DIREC_INTERNET { set; get; }
        public string COM_RESP_TELEFONO { set; get; }
        public string COM_RESP_TEL_EXT { set; get; }
        public string COM_RESP_CARGO { set; get; }
        public string COM_RESP_EMAIL { set; get; }
        [Required]
        [Display(Name = "Código sucursal")]
        public string COM_DESCORTA { set; get; }

        public virtual ICollection<Sucursales> sucursales {set; get;}
     
    }
}
